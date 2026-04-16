using System.ComponentModel.DataAnnotations;

namespace UPZMG.Persistence.Models;

/// <summary>
/// Academic module.
/// Represents a class group in the academic system.
/// </summary>

public class ClassGroups
{
    public Guid Id { get; set; }
    public Guid PeriodId { get; set; } //fk
    public Guid CareerId { get; set; } //fk
    public int Semester { get; set; }
    [MaxLength(10)]
    public string? GroupIdentifier { get; set; }
    public Guid TeacherId { get; set; } //fk
    public Guid FacilityId { get; set; } //fk to SchoolFacility
    public int MaxStudents { get; set; }
}