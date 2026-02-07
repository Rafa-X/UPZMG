using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UPZMG.Persistence;
using UPZMG.Persistence.Models;

namespace UPZMG.Web.Controllers;

public class AccountController : Controller
{
    private readonly DBContext _db;
    private readonly IWebHostEnvironment _env;

    public AccountController(DBContext db, IWebHostEnvironment env)
    {
        _db = db;
        _env = env;
    }

    [HttpPost]
    public async Task<IActionResult> Login(string email, string password)
    {
        // Development mode: it auto-logs you in as an Admin user with claims for Admin and Developer roles.
        // Bypasses the login form and redirects to Home.
        // For production (Release mode), the normal login form still appears.
        var claims = new List<Claim>();
        var identity = new ClaimsIdentity();

        if (_env.IsDevelopment())
        {
            // Create a dev admin user with claims
            claims.Add(new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()));
            claims.Add(new Claim(ClaimTypes.Email, "dev@admin.local"));
            claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            claims.Add(new Claim(ClaimTypes.Role, "Developer"));

            identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity));

            return RedirectToAction("Index", "Home");
            // Later improvements: You can refine this to:
            // Use a test user from the database instead of a hardcoded dev user
            // Add a query parameter to bypass it if needed
            // Log the auto-login for debugging
        }

        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            ModelState.AddModelError("", "Username and password are required.");
            return View();
        }

        // 1) Find active user
        var user = await _db.SystemUser
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Email == email && x.Active);

        if (user is null)
        {
            ModelState.AddModelError("", "Invalid credentials.");
            return View();
        }

        // 2) Verify password hash
        var hasher = new PasswordHasher<SystemUser>();
        var result = hasher.VerifyHashedPassword(user, user.Password, password);

        if (result == PasswordVerificationResult.Failed)
        {
            ModelState.AddModelError("", "Invalid credentials.");
            return View();
        }

        // 3) Load roles
        var roles = await (
            from ur in _db.UserRole.AsNoTracking()
            join r in _db.Role.AsNoTracking() on ur.RoleId equals r.Id
            where ur.UserId == user.Id
            select r.Name
        ).ToListAsync();

        // 4) Create cookie claims
        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
        claims.Add(new Claim(ClaimTypes.Email, user.Email));
        claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

        identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(identity));

        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login");
    }

    public IActionResult AccessDenied() => View();
}
