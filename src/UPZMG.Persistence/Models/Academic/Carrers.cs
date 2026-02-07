using System.ComponentModel.DataAnnotations;
using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models;

/// <summary>
/// Academic module.
/// Represents kardex courses record of students in the academic system.
/// </summary>

public class Carrers
{
    public Guid Id { get; set; }
    [MaxLength(200)]
    public string? Name { get; set; }
    [MaxLength(50)]
    public string? SEPCode { get; set; }
    public EducationalLevel EducationalLevel { get; set; }
    public Modality Modality { get; set; }
    public PeriodType PeriodType { get; set; }
    public int DurationInPeriods { get; set; }
    public int TotalCredits { get; set; }
    public DateOnly PlanCreadtedDate { get; set; }
    public DateOnly LastUpdatedDate { get; set; }
}