using System.ComponentModel.DataAnnotations;
using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models;

/// <summary>
/// Resources module.
/// Represents a school facility in the university, such as classrooms, auditoriums, offices, etc.
/// </summary>

public class SchoolFacility
{
    public Guid Id { get; set; }
    [MaxLength(50)]
    public string Name { get; set; } = null!;
    public SchoolFacilityType Type { get; set; }
    public int Capacity { get; set; }
    public bool InUse { get; set; }
    public bool HasInternet { get; set; }
    public bool HasComputers { get; set; }
    public bool SupportDisabilities { get; set; }
    public List<string> Problems { get; set; } = null!;
}