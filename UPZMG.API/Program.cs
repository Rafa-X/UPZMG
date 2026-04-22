using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using UPZMG.Persistence;

var builder = WebApplication.CreateBuilder(args);
using var startupLoggerFactory = CreateStartupLoggerFactory();
var startupLogger = startupLoggerFactory.CreateLogger("Startup");

try
{
    startupLogger.LogInformation("Validating API startup secrets.");

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<AppDBContext>(opt =>
        opt.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

    var jwt = builder.Configuration.GetSection("Jwt");
    var jwtSigningKey = GetRequiredSecret(builder.Configuration, "Jwt:Key", 32, startupLogger);
    ValidateRequiredSecret(builder.Configuration, "InternalAuth:WebSharedSecret", 32, startupLogger);
    var keyBytes = Encoding.UTF8.GetBytes(jwtSigningKey);

    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwt["Issuer"],
                ValidAudience = jwt["Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
                ClockSkew = TimeSpan.FromSeconds(30)
            };
        });

    builder.Services.AddSingleton<UPZMG.Api.Services.ISecurityEventLogger, UPZMG.Api.Services.SecurityLogger>();
    builder.Services.AddAuthorization();

    startupLogger.LogInformation("API secret validation completed successfully.");

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Logger.LogInformation("UPZMG API starting.");
    app.Run();
}
catch (Exception ex)
{
    startupLogger.LogCritical(ex, "UPZMG API startup aborted.");
    throw;
}

static ILoggerFactory CreateStartupLoggerFactory()
{
    return LoggerFactory.Create(logging =>
    {
        logging.SetMinimumLevel(LogLevel.Information);
        logging.AddSimpleConsole(options =>
        {
            options.SingleLine = true;
            options.TimestampFormat = "yyyy-MM-dd HH:mm:ss ";
        });
    });
}

static string GetRequiredSecret(IConfiguration configuration, string key, int minLength, ILogger logger)
{
    logger.LogInformation("Validating required secret configuration {SecretKey}.", key);

    var value = configuration[key];
    if (string.IsNullOrWhiteSpace(value))
        throw new InvalidOperationException($"Missing configuration '{key}'. Configure it via user secrets or environment variables.");

    if (value.StartsWith("CHANGE_", StringComparison.OrdinalIgnoreCase))
        throw new InvalidOperationException($"Configuration '{key}' still uses a placeholder value. Configure a real secret via user secrets or environment variables.");

    if (value.Length < minLength)
        throw new InvalidOperationException($"Configuration '{key}' must be at least {minLength} characters long.");

    logger.LogInformation("Required secret configuration {SecretKey} loaded successfully.", key);
    return value;
}

static void ValidateRequiredSecret(IConfiguration configuration, string key, int minLength, ILogger logger)
{
    _ = GetRequiredSecret(configuration, key, minLength, logger);
}
