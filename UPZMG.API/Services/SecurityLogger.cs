namespace UPZMG.Api.Services;

public interface ISecurityEventLogger
{
    void LogTokenExchangeRejected(Guid userId, string reason);
    void LogTokenIssued(Guid userId, IReadOnlyCollection<string> roles, DateTime expiresUtc);
}

public sealed class SecurityLogger : ISecurityEventLogger
{
    private readonly ILogger<SecurityLogger> _logger;

    public SecurityLogger(ILogger<SecurityLogger> logger)
    {
        _logger = logger;
    }

    public void LogTokenExchangeRejected(Guid userId, string reason)
    {
        _logger.LogWarning("JWT token exchange rejected for user {UserId}. Reason: {Reason}.", userId, reason);
    }

    public void LogTokenIssued(Guid userId, IReadOnlyCollection<string> roles, DateTime expiresUtc)
    {
        _logger.LogInformation(
            "JWT access token issued for user {UserId}. RoleCount: {RoleCount}. ExpiresUtc: {ExpiresUtc}.",
            userId,
            roles.Count,
            expiresUtc);
    }
}