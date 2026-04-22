using System.ComponentModel.DataAnnotations;
using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models;

/// <summary>
/// Extension module.
/// Represents a student continuous education record.
/// </summary>

public class ContinuousEducation
{
    public Guid Id { get; set; }
    [MaxLength(200)]
    public string? ProgramName { get; set; }
    public bool HasCurricularRecognition { get; set; }
    public int TotalMaleParticipants { get; set; }
    public int TotalFemaleParticipants { get; set; }
    public Guid PeriodId { get; set; } //fk
}