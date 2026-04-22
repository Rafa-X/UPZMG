using System.ComponentModel.DataAnnotations;
using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models;

/// <summary>
/// RRHH module.
/// Represents the mapping of positions within the HR system.
/// </summary>

public class PositionsMapping
{
    public Guid Id { get; set; }
    [MaxLength(150)]
    public string? InternalName { get; set; }
    public SEP_911? SEP_Category { get; set; }
}