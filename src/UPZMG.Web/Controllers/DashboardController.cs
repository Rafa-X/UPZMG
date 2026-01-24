using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UPZMG.Web.Services;

namespace UPZMG.Web.Controllers;

[Authorize] // only logged-in users
public class DashboardController : Controller
{
    private readonly ApiClient _api;

    public DashboardController(ApiClient api)
    {
        _api = api;
    }

    public async Task<IActionResult> Index()
    {
        var userIdText = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrWhiteSpace(userIdText))
            return RedirectToAction("Login", "Account");

        var userId = Guid.Parse(userIdText);

        var data = await _api.GetExampleDataAsync(userId);

        return View(data); // send data to Razor view
    }
}

/*
using System.Net.Http.Headers;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UPZMG.Web.Services;

namespace UPZMG.Web.Controllers;

[Authorize]
public class DashboardController : Controller
{
    private readonly IHttpClientFactory _http;
    private readonly ApiTokenService _tokens;

    public DashboardController(IHttpClientFactory http, ApiTokenService tokens)
    {
        _http = http;
        _tokens = tokens;
    }

    public async Task<IActionResult> Index()
    {
        var userIdText = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrWhiteSpace(userIdText) || !Guid.TryParse(userIdText, out var userId))
            return Unauthorized("Missing user id claim.");

        // 1) Web gets a JWT from API
        var token = await _tokens.GetTokenAsync(userId);

        // 2) Web calls protected API endpoint
        var client = _http.CreateClient("UpzmgApi");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var apiResponse = await client.GetStringAsync("test_jwt");

        // Show raw JSON for the test
        ViewBag.ApiJson = apiResponse;
        return View();
    }
}
*/