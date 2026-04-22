using System.ComponentModel.DataAnnotations;

namespace UPZMG.Persistence.Models;

/// <summary>
/// RRHH module.
/// Represents research areas associated with the Academic Staff (AS).
/// </summary>

public class ResearchAreas
{
    public Guid Id { get; set; }
    public Guid ASId { get; set; } //fk
    [MaxLength(200)]
    public string? AreaName { get; set; }
}