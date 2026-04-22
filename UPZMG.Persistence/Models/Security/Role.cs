using System.ComponentModel.DataAnnotations;

namespace UPZMG.Persistence.Models;

/// <summary>
/// Security module.
/// Represents a role that can be assigned to system users.
/// </summary>

public class Role
{
    public Guid Id { get; set; }
    [MaxLength(40)]
    public string Name { get; set; } = null!;
}