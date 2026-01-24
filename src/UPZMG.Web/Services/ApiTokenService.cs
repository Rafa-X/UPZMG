using System.Net.Http.Json;
using Microsoft.Extensions.Caching.Memory;

namespace UPZMG.Web.Services;

public class ApiTokenService
{
    private readonly IHttpClientFactory _factory;
    private readonly IMemoryCache _cache;
    private readonly IConfiguration _cfg;

    public ApiTokenService(IHttpClientFactory factory, IMemoryCache cache, IConfiguration cfg)
    {
        _factory = factory;
        _cache = cache;
        _cfg = cfg;
    }

    public async Task<string> GetTokenAsync(Guid userId)
    {
        var cacheKey = $"api_token:{userId}";
        if (_cache.TryGetValue<string>(cacheKey, out var token) && !string.IsNullOrWhiteSpace(token))
            return token!;

        var client = _factory.CreateClient("UpzmgApi");
        var secret = _cfg["InternalAuth:WebSharedSecret"] ?? throw new InvalidOperationException("Missing shared secret.");

        var resp = await client.PostAsJsonAsync("auth/token", new { userId, sharedSecret = secret });
        resp.EnsureSuccessStatusCode();

        var body = await resp.Content.ReadFromJsonAsync<TokenResponse>();
        token = body?.access_token ?? throw new InvalidOperationException("No token returned.");

        // Cache slightly less than token lifetime
        _cache.Set(cacheKey, token, TimeSpan.FromMinutes(14));
        return token;
    }

    private record TokenResponse(string access_token);
}