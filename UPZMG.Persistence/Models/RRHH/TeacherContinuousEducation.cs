using System.ComponentModel.DataAnnotations;
using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models;

/// <summary>
/// RRHH module.
/// Represents a teacher's continuous education record.
/// </summary>

public class TeacherContinuousEducation
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; } //fk
    public EducationLevel? EducationLevel { get; set; }
    public StudyPlace? StudyPlace { get; set; }
    public bool HasScholarship { get; set; }
    [MaxLength(200)]
    public string? InstitutionDestination { get; set; }
    public DateOnly? StartDate { get; set; }
    public Guid PeriodId { get; set; } //fk
}