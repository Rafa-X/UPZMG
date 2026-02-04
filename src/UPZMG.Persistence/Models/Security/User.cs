using System.ComponentModel.DataAnnotations;

namespace UPZMG.Persistence.Models;

/// <summary>
/// Security module.
/// Represents a system user that can log into UPZMG.Web.
/// </summary>

public class Users
{
    public Guid Id { get; set; }
    [StringLength(50)]
    public string Email { get; set; } = null!;
    [StringLength(30)]
    public string Password { get; set; } = null!;
    public bool Active { get; set; } = true;
    public DateTime LastLogin { get; set; } = DateTime.MinValue;
}