namespace UPZMG.Persistence.Models;

/// <summary>
/// Security module.
/// Represents a system user role assignment in the system.
/// </summary>

public class UserRole
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; } //fk
    public Guid RoleId { get; set; } //fk
}