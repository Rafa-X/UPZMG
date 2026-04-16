namespace UPZMG.Persistence.Models;

/// <summary>
/// Resources module.
/// Represents the parking lot details in the university.
/// </summary>

public class ParkingLots
{
    public Guid Id { get; set; }
    public Guid PeriodId { get; set; } //fk
    public int StudentParkings { get; set; }
    public int FacultyParkings { get; set; }
    public int AdministrativeParkings { get; set; }
    public int DisabilityParkings { get; set; }
    public int OthersParkings { get; set; }
}