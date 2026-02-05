using System.ComponentModel.DataAnnotations;
using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models;

/// <summary>
/// Academic module.
/// Represents a student in the academic system.
/// </summary>

public class Student
{
    public Guid Id { get; set; }
    [MaxLength(50)]
    public required string EnrollmentNumber { get; set; }
    [MaxLength(18)]
    public required string CURP { get; set; }
    [MaxLength(100)]
    public required string FirstName { get; set; }
    [MaxLength(100)]
    public required string LastName { get; set; }
    [MaxLength(100)]
    public DateOnly BirthDate { get; set; }
    public GenderType Gender { get; set; }
    public bool SpeaksIndigenousLanguage { get; set; }
    [MaxLength(10)]
    public string PostalCode { get; set; } = null!;
    public EnglishLevel EnglishLevel { get; set; }
    public MaritalStatus MaritalStatus { get; set; }
    public int NumberOfChildren { get; set; }
    public bool Works { get; set; }
    [MaxLength(50)]
    public string BirthCountry { get; set; } = null!;
    [MaxLength(50)]
    public string BirthState { get; set; } = null!;
    [MaxLength(50)]
    public string HighSchoolCountry { get; set; } = null!;
    [MaxLength(50)]
    public string HighSchoolEntity { get; set; } = null!;
}