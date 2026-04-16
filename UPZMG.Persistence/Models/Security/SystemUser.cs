using System.ComponentModel.DataAnnotations;

namespace UPZMG.Persistence.Models;

/// <summary>
/// Security module.
/// Represents a system user in the security system.
/// </summary>

public class SystemUser
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; } //fk
    [MaxLength(100)]
    public string Email { get; set; } = null!;
    [MaxLength(50)]
    public string Password { get; set; } = null!;
    public bool IsActive { get; set; }
    public DateTime LastLogin { get; set; }
}