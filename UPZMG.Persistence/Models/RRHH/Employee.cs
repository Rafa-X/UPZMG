using System.ComponentModel.DataAnnotations;
using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models;

/// <summary>
/// RRHH module.
/// Represents an employee in the HR system.
/// </summary>

public class Employee
{
    public Guid Id { get; set; }
    public required Guid EmployeeNumber { get; set; }
    [MaxLength(200)]
    public required string FullName { get; set; }
    [MaxLength(13)]
    public required string Rfc { get; set; }
    [MaxLength(18)]
    public required string Curp { get; set; }
    public Gender Gender { get; set; }
    public DateOnly BirthDate { get; set; }
    public EducationLevel HighestEducationLevel { get; set; }
    public TitleStatus TitleStatus { get; set; }
    public bool SpeaksIndigenousLanguage { get; set; }
    public bool HasDisability { get; set; }
    public int ExternalXPYears { get; set; }
    public DateOnly FirstHiredDate { get; set; }
}