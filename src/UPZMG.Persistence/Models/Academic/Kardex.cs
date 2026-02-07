using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models;

/// <summary>
/// Academic module.
/// Represents kardex courses record of students in the academic system.
/// </summary>

public class Kardex
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
    public Guid PeriodId { get; set; }
    public float Grade { get; set; }
    public bool IsPassed { get; set; }
    public Opportunity Opportunity { get; set; }
}