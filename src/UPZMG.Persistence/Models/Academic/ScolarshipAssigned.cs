using System.ComponentModel.DataAnnotations;
using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models;

/// <summary>
/// Academic module.
/// Represents a scolarship assigned to a student in the academic system.
/// </summary>

public class ScolarshipAssigned
{
    public Guid Id { get; set; }
    public Guid ScolarshipId { get; set; }
    public Guid PeriodId { get; set; }
    public Guid StudentId { get; set; }
    [MaxLength(100)]
    public string? ScolarshipObjective { get; set; }
    public FinantialSource Source { get; set; }
    public float Amount { get; set; }
    public DateOnly AssignedDate { get; set; }
}