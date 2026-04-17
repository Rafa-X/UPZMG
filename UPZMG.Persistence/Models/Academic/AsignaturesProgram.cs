using System.ComponentModel.DataAnnotations;

namespace UPZMG.Persistence.Models;

/// <summary>
/// Academic module.
/// Represents a course program in the academic system.
/// </summary>

public class AsignaturesProgram
{
    public Guid Id { get; set; }
    public Guid CareerId { get; set; } //fk
    public Guid AsignatureCode { get; set; }
    [MaxLength(200)]
    public string AsignatureName { get; set; } = null!;
    public int Credits { get; set; }
    public bool IsCoreSubject { get; set; }
}