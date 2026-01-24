using System.Net.Http.Headers;
using System.Net.Http.Json;
using UPZMG.Web.Services;

namespace UPZMG.Web.Services;

public class ApiClient
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ApiTokenService _tokenService;

    public ApiClient(IHttpClientFactory httpClientFactory, ApiTokenService tokenService)
    {
        _httpClientFactory = httpClientFactory;
        _tokenService = tokenService;
    }

    // Generic helper: prepare client with Bearer token
    private async Task<HttpClient> CreateAuthorizedClientAsync(Guid userId)
    {
        var token = await _tokenService.GetTokenAsync(userId);

        var client = _httpClientFactory.CreateClient("UpzmgApi");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        return client;
    }

    // Example API call (you can create as many as you need)
    public async Task<List<string>> GetExampleDataAsync(Guid userId)
    {
        var client = await CreateAuthorizedClientAsync(userId);

        // Example endpoint: GET /example
        var result = await client.GetFromJsonAsync<List<string>>("example");

        return result ?? new List<string>();
    }
}
