using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models;

/// <summary>
/// Academic module.
/// Represents kardex courses record of students in the academic system.
/// </summary>

public class Kardex
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; } //fk
    public Guid AsignatureId { get; set; } //fk
    public Guid PeriodId { get; set; } //fk
    public double Grade { get; set; }
    public bool IsPassed { get; set; }
    public Opportunity Opportunity { get; set; }
}