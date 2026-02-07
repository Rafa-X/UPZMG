using System.ComponentModel.DataAnnotations;
using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models;

/// <summary>
/// RRHH module.
/// Represents an academic staff and Academic Committee member in the RRHH system.
/// </summary>

public class AcademicStaff
{
    public Guid Id { get; set; }
    public Guid AC_Id { get; set; }
    [MaxLength(200)]
    public string? Name { get; set; }
    public StatusAC Status { get; set; }
}