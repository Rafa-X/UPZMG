namespace UPZMG.Persistence.Models;

/// <summary>
/// Security module.
/// Represents the mapping of positions within the HR system.
/// </summary>

public class EmployeePositions
{
    public Guid Id { get; set; }
    public required Guid InternalName { get; set; }
    public string SEP_Category { get; set; } = null!;
}