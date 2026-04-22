using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UPZMG.Persistence;
using UPZMG.Persistence.Models;
using UPZMG.Web.Services;

namespace UPZMG.Web.Controllers;

public class AccountController : Controller
{
    private readonly AppDBContext _db;
    private readonly ISecurityEventLogger _securityLogger;

    public AccountController(AppDBContext db, ISecurityEventLogger securityLogger)
    {
        _db = db;
        _securityLogger = securityLogger;
    }

    [AllowAnonymous]
    [HttpGet]
    public IActionResult Login()
    {   
        //show login page if not authenticated, otherwise redirect to home
        if (User.Identity?.IsAuthenticated == true)
            return RedirectToAction("Index", "Home");

        return View();
    }

    [AllowAnonymous]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(string email, string password)
    {   
        //handle login form submission, validate credentials, and sign in with cookie auth
        if (User.Identity?.IsAuthenticated == true)
            return RedirectToAction("Index", "Home");

        var claims = new List<Claim>();
        var identity = new ClaimsIdentity();
        var props = new AuthenticationProperties
        {
            IsPersistent = false,
            AllowRefresh = false
        };

        email = email?.Trim() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            _securityLogger.LogLoginRejected(email, "Missing credentials");
            ModelState.AddModelError("", "Email and password are required.");
            return View();
        }

        // 1) Find active user
        var user = await _db.SystemUsers
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Email == email && x.IsActive);

        if (user is null)
        {
            _securityLogger.LogLoginRejected(email, "User not found or inactive");
            ModelState.AddModelError("", "Invalid credentials.");
            return View();
        }

        // 2) Verify password hash
        var hasher = new PasswordHasher<SystemUser>();
        var result = hasher.VerifyHashedPassword(user, user.Password, password);

        if (result == PasswordVerificationResult.Failed)
        {
            _securityLogger.LogLoginRejected(email, "Invalid password");
            ModelState.AddModelError("", "Invalid credentials.");
            return View();
        }

        // 3) Load roles
        var roles = await (
            from ur in _db.UserRoles.AsNoTracking()
            join r in _db.Roles.AsNoTracking() on ur.RoleId equals r.Id
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
                new ClaimsPrincipal(identity),
                props);
        _securityLogger.LogLoginSucceeded(user.Id, user.Email, roles);
        return RedirectToAction("Index", "Home");
    }

    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        //handle logout, sign out of cookie auth, and log the event
        var userIdValue = User.FindFirstValue(ClaimTypes.NameIdentifier);
        Guid? userId = Guid.TryParse(userIdValue, out var parsedUserId) ? parsedUserId : null;
        var email = User.FindFirstValue(ClaimTypes.Email);

        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        _securityLogger.LogLogout(userId, email);
        return RedirectToAction("Login");
    }

    public IActionResult AccessDenied() => View();
}
