using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models;

/// <summary>
/// RRHH module.
/// Represents a teacher in the Academic Staff (AS).
/// </summary>

public class ASTeacher
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; } //fk
    public Guid ASId { get; set; } //fk
    public RoleAS Role { get; set; }
}