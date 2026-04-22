using System.ComponentModel.DataAnnotations;

namespace UPZMG.Persistence.Models;

/// <summary>
/// Security module.
/// Represents report permissions assigned to roles.
/// </summary>

public class ReportsPermission
{
    public Guid Id { get; set; }
    public Guid RoleId { get; set; } //fk
    [MaxLength(50)]
    public string ReportName { get; set; } = null!;
    public bool CanEdit { get; set; }
    public bool CanSign { get; set; }
}