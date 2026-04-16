using System.ComponentModel.DataAnnotations;

namespace UPZMG.Persistence.Models;

/// <summary>
/// Public module.
/// Represents a disability in the public system.
/// </summary>

public class Disabilities
{
    public Guid Id { get; set; }
    [MaxLength(100)]
    public string? Name { get; set; }
}