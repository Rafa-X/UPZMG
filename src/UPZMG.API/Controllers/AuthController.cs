using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using UPZMG.Persistence;

namespace UPZMG.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly DBContext _db;
    private readonly IConfiguration _cfg;

    public AuthController(DBContext db, IConfiguration cfg)
    {
        _db = db;
        _cfg = cfg;
    }

    public record TokenExchangeRequest(Guid UserId, string SharedSecret);

    [HttpPost("token")]
    public async Task<IActionResult> Token([FromBody] TokenExchangeRequest req)
    {
        var expected = _cfg["InternalAuth:WebSharedSecret"];
        if (string.IsNullOrWhiteSpace(expected) || req.SharedSecret != expected)
            return Unauthorized();

        var user = await _db.SystemUser.FirstOrDefaultAsync(x => x.Id == req.UserId && x.Active);
        if (user is null) return Unauthorized();

        var roles = await (from ur in _db.UserRole
                           join r in _db.Role on ur.RoleId equals r.Id
                           where ur.UserId == user.Id
                           select r.Name).ToListAsync();

        var jwt = _cfg.GetSection("Jwt");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
        };
        claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

        var minutes = int.Parse(jwt["AccessTokenMinutes"] ?? "15");
        var token = new JwtSecurityToken(
            issuer: jwt["Issuer"],
            audience: jwt["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(minutes),
            signingCredentials: creds
        );

        return Ok(new { access_token = new JwtSecurityTokenHandler().WriteToken(token) });
    }
}


/*
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace UPZMG.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _cfg;
    public AuthController(IConfiguration cfg) => _cfg = cfg;

    public record TokenExchangeRequest(Guid UserId, string SharedSecret);

    [HttpPost("token")]
    public IActionResult Token([FromBody] TokenExchangeRequest req)
    {
        var expected = _cfg["InternalAuth:WebSharedSecret"];
        if (string.IsNullOrWhiteSpace(expected) || req.SharedSecret != expected)
            return Unauthorized();

        var jwt = _cfg.GetSection("Jwt");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // Minimal claims for the test
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, req.UserId.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, "test-user"),
            new Claim(ClaimTypes.Role, "Admin")
        };

        var minutes = int.Parse(jwt["AccessTokenMinutes"] ?? "15");
        var token = new JwtSecurityToken(
            issuer: jwt["Issuer"],
            audience: jwt["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(minutes),
            signingCredentials: creds
        );

        return Ok(new { access_token = new JwtSecurityTokenHandler().WriteToken(token) });
    }
}
*/