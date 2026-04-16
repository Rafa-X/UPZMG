using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using UPZMG.Persistence;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDBContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

// Cookie Auth
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
        options.Cookie.Name = "UPZMG.Auth";
        options.SlidingExpiration = true;
        options.ExpireTimeSpan = TimeSpan.FromHours(8);
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.Cookie.SameSite = SameSiteMode.Lax;
    });
    

builder.Services.AddScoped<UPZMG.Web.Services.ApiTokenService>();
builder.Services.AddScoped<UPZMG.Web.Services.ApiClient>();

builder.Services.AddAuthorization();

// HttpClient to call API (server-to-server)
builder.Services.AddHttpClient("UpzmgApi", client =>
{
    // dev: your API will run on another port; update once you know it
    client.BaseAddress = new Uri("https://localhost:5003/");
});

builder.Services.AddMemoryCache(); // for caching JWT per session/user

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

//default route: HomeController -> Index action
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
