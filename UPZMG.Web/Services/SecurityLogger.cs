namespace UPZMG.Web.Services;

public interface ISecurityEventLogger
{
    void LogLoginRejected(string email, string reason);
    void LogLoginSucceeded(string email, IReadOnlyCollection<string> roles);
    void LogLogout(Guid? userId, string? email);
    void LogApiTokenCacheHit(Guid userId);
    void LogApiTokenRequest(Guid userId);
    void LogApiTokenReceived(Guid userId);
    void LogApiTokenRequestFailed(Guid userId, Exception ex);
}

public sealed class SecurityLogger : ISecurityEventLogger
{
    private readonly ILogger<SecurityLogger> _logger;

    public SecurityLogger(ILogger<SecurityLogger> logger)
    {
        _logger = logger;
    }

    public void LogLoginRejected(string email, string reason)
    {
        _logger.LogWarning("Web login rejected for {Email}. Reason: {Reason}.", email, reason);
    }

    public void LogLoginSucceeded(string email, IReadOnlyCollection<string> roles)
    {
        _logger.LogInformation(
            "Web login succeeded for user ({Email}). RoleCount: {RoleCount}.",
            email,
            roles.Count);
    }

    public void LogLogout(Guid? userId, string? email)
    {
        _logger.LogInformation("Web logout completed for user {UserId} ({Email}).", userId, email);
    }

    public void LogApiTokenCacheHit(Guid userId)
    {
        _logger.LogInformation("Using cached API access token for user {UserId}.", userId);
    }

    public void LogApiTokenRequest(Guid userId)
    {
        _logger.LogInformation("Requesting API access token for user {UserId}.", userId);
    }

    public void LogApiTokenReceived(Guid userId)
    {
        _logger.LogInformation("Received API access token for user {UserId}.", userId);
    }

    public void LogApiTokenRequestFailed(Guid userId, Exception ex)
    {
        _logger.LogError(ex, "Failed to obtain API access token for user {UserId}.", userId);
    }
}