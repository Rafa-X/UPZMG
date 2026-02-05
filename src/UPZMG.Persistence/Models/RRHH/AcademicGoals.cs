using System.ComponentModel.DataAnnotations;
using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models;

/// <summary>
/// RRHH module.
/// Represents academic goals for employees.
/// </summary>

public class AcademicGoals
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    [MaxLength(10)]
    public GoalType? Type { get; set; }
    [MaxLength(50)]
    public string? Level { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
}