using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UPZMG.Api.Controllers;

[ApiController]
[Route("example")]
public class ExampleController : ControllerBase
{
    [HttpGet]
    [Authorize] // requires JWT
    public IActionResult Get()
    {
        return Ok(new List<string> { "Hello from API", "JWT auth works ✅" });
    }
}
