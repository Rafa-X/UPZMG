namespace UPZMG.Persistence.Models;

/// <summary>
/// Security module.
/// Represents contracts associated with employees and positions.
/// </summary>

public class Contracts
{
    public Guid Id { get; set; }
    public required Guid EmployeeId { get; set; }
    public required Guid PositionId { get; set; }
    public required Guid AreaId { get; set; }
    public required Guid PeriodId { get; set; }
    public string WorkdayType { get; set; } = null!;
    public string TabLevel { get; set; } = null!;
    public int WeeklyHours { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
}