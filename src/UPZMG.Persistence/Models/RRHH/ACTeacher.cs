using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models;

/// <summary>
/// RRHH module.
/// Represents a teacher in the Academic Committee (AC).
/// </summary>

public class ACTeacher
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public Guid AC_Id { get; set; }
    public RoleCA Role { get; set; }
}