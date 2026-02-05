namespace UPZMG.Persistence.Models;

/// <summary>
/// RRHH module.
/// Represents an employee in the HR system.
/// </summary>

public class Employee
{
    public Guid Id { get; set; }
    public required Guid EmployeeNumber { get; set; }
    public required string Name { get; set; }
    public required string Rfc { get; set; }
    public required string Curp { get; set; }
    public string Gender { get; set; } = null!;
    public DateOnly BirthDate { get; set; }
    public string HighestEducationLevel { get; set; } = null!;
    public string TitleStatus { get; set; } = null!;
    public bool SpeaksIndigenousLanguage { get; set; }
    public bool WithDisability { get; set; }
    public float ExternalExpYears { get; set; }
    public DateOnly FirstHiredDate { get; set; }
}