namespace UPZMG.Persistence.Models;

/// <summary>
/// Academic module.
/// Represents an academic load in the academic system.
/// </summary>

public class AcademicLoad
{
    public Guid Id { get; set; }
    public Guid GroupId { get; set; }
    public Guid CourseId { get; set; }
    public Guid TeacherId { get; set; }
    public Guid FacilityId { get; set; } //fk to SchoolFacility
    public int WeekHours { get; set; }
}