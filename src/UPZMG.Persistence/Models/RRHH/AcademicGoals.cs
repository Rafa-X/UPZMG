namespace UPZMG.Persistence.Models;

/// <summary>
/// Security module.
/// Represents academic goals for employees.
/// </summary>

public class AcademicGoals
{
    public Guid Id { get; set; }
    public required Guid EmployeeId { get; set; }
    public string GoalType { get; set; } = null!;
    public string Level { get; set; } = null!;
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
}