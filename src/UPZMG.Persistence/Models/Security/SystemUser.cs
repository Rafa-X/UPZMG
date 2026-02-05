using System.ComponentModel.DataAnnotations;

namespace UPZMG.Persistence.Models;

/// <summary>
/// Security module.
/// Represents a system user in the security system.
/// </summary>

public class SystemUser
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    [MaxLength(60)]
    public string Email { get; set; } = null!;
    [MaxLength(30)]
    public string Password { get; set; } = null!;
    public bool Active { get; set; }
    public DateTime LastLogin { get; set; }
}