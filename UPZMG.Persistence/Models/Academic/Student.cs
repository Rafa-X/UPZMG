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
    [MaxLength(20)]
    public required string EnrollmentNumber { get; set; }
    [MaxLength(18)]
    public required string CURP { get; set; }
    [MaxLength(100)]
    public required string Name { get; set; }
    [MaxLength(100)]
    public required string MiddleName { get; set; }
    [MaxLength(100)]
    public required string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
    public Gender Gender { get; set; }
    public bool SpeaksIndigenousLanguage { get; set; }
    public Guid IndigenousLanguage { get; set; }
    [MaxLength(10)]
    public string? PostalCode { get; set; }
    public EnglishLevel EnglishLevel { get; set; }
    public MaritalStatus MaritalStatus { get; set; }
    public int NumberOfChildren { get; set; }
    public bool Works { get; set; }
    [MaxLength(100)]
    public string? BirthCountry { get; set; }
    [MaxLength(100)]
    public string? BirthState { get; set; }
    [MaxLength(100)]
    public string? HighSchoolCountry { get; set; }
    [MaxLength(100)]
    public string? HighSchoolEntity { get; set; }
}