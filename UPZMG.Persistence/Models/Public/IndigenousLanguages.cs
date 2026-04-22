using System.ComponentModel.DataAnnotations;

namespace UPZMG.Persistence.Models;

/// <summary>
/// Public module.
/// Represents the indigenous languages spoken by students in the academic system.
/// </summary>

public class IndigenousLanguages
{
    public Guid Id { get; set; }
    [MaxLength(100)]
    public string? LanguageName { get; set; }
}