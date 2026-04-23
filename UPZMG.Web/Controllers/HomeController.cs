using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using UPZMG.Web.Models;
using UPZMG.Web.Services;

namespace UPZMG.Web.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApiClient _api;

    public HomeController(ApiClient api, ILogger<HomeController> logger)
    {
        _api = api;
        _logger = logger;
    }

    public async Task<IActionResult> Index(HomeModel? model = null)
    {
        model ??= new HomeModel();  // ??= assignation means if model is null, create a new one
        
        //Extracts the logged-in user's ID from the JWT/authentication token.
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); //claims (identity information)
        if (string.IsNullOrWhiteSpace(userId))
            return RedirectToAction("Login", "Account");

        var data = await _api.GetExampleDataAsync(Guid.Parse(userId)); //calls the API client to get data from the protected API using the user's ID.

        // Compose a page view model that contains the incoming HomeModel and API data
        model.RequestId = model.RequestId;
        model.Data = data;

        return View(model); // send composite model to Razor view
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
