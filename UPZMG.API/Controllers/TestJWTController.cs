using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UPZMG.Api.Controllers;

[ApiController]
[Route("test_jwt")]
public class TestJWTController : ControllerBase
{
    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                     ?? User.FindFirstValue("sub")
                     ?? "(no-sub)";

        var name = User.Identity?.Name ?? User.FindFirstValue("unique_name") ?? "(no-name)";

        var roles = User.FindAll(ClaimTypes.Role).Select(r => r.Value).ToList();

        return Ok(new
        {
            message = "JWT auth works ✅",
            userId,
            name,
            roles,
            nowUtc = DateTime.UtcNow
        });
    }
}
