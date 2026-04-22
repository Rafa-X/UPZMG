using System.Net.Http.Json;
using Microsoft.Extensions.Caching.Memory;

namespace UPZMG.Web.Services;

public class ApiTokenService
{
    private readonly IHttpClientFactory _factory;
    private readonly IMemoryCache _cache;
    private readonly IConfiguration _cfg;
    private readonly ISecurityEventLogger _securityLogger;

    public ApiTokenService(IHttpClientFactory factory, IMemoryCache cache, IConfiguration cfg, ISecurityEventLogger securityLogger)
    {
        _factory = factory;
        _cache = cache;
        _cfg = cfg;
        _securityLogger = securityLogger;
    }

    public async Task<string> GetTokenAsync(Guid userId)
    {
        var cacheKey = $"api_token:{userId}";
        //Already have a valid token in cache, return it
        if (_cache.TryGetValue<string>(cacheKey, out var token) && !string.IsNullOrWhiteSpace(token))
        {
            _securityLogger.LogApiTokenCacheHit(userId);
            return token!;
        }

        try
        {
            _securityLogger.LogApiTokenRequest(userId);

            //If not, call the API to get a new token using the shared secret for authentication
            var client = _factory.CreateClient("UpzmgApi");
            var secret = _cfg["InternalAuth:WebSharedSecret"] ?? throw new InvalidOperationException("Missing shared secret.");

            var resp = await client.PostAsJsonAsync("auth/token", new { userId, sharedSecret = secret });
            resp.EnsureSuccessStatusCode();

            var body = await resp.Content.ReadFromJsonAsync<TokenResponse>();
            token = body?.access_token ?? throw new InvalidOperationException("No token returned.");

            // Cache slightly less than token lifetime
            _cache.Set(cacheKey, token, TimeSpan.FromMinutes(14));
            _securityLogger.LogApiTokenReceived(userId);
            return token;
        }
        catch (Exception ex)
        {
            _securityLogger.LogApiTokenRequestFailed(userId, ex);
            throw;
        }
    }

    private record TokenResponse(string access_token);
}