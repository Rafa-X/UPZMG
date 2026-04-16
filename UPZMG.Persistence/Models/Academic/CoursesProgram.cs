using System.ComponentModel.DataAnnotations;

namespace UPZMG.Persistence.Models;

/// <summary>
/// Academic module.
/// Represents a course program in the academic system.
/// </summary>

public class CoursesProgram
{
    public Guid Id { get; set; }
    public Guid CareerId { get; set; } //fk
    public Guid Code { get; set; }
    [MaxLength(200)]
    public string Name { get; set; } = null!;
    public int Credits { get; set; }
    public bool IsCoreSubject { get; set; }
}