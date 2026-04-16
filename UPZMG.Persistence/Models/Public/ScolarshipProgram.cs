using System.ComponentModel.DataAnnotations;
using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models;

/// <summary>
/// Public module.
/// Represents a scolarship program in the academic system.
/// </summary>

public class ScolarshipProgram
{
    public Guid Id { get; set; }
    [MaxLength(150)]
    public string OfficialName { get; set; } = null!;
    public FinantialSource SourceType { get; set; }
}