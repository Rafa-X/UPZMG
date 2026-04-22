using System.ComponentModel.DataAnnotations;

namespace UPZMG.Persistence.Models;

/// <summary>
/// Academic module.
/// Represents an institutional configuration in the academic system.
/// </summary>

public class InstitutionalConfiguration
{
    public Guid Id { get; set; }
    public Guid PeriodId { get; set; }
    public bool IsActive { get; set; }
    public bool IsEvaluated { get; set; }
    public bool PublicResults { get; set; }
    [MaxLength(500)]
    public string? URLResults { get; set; }
    public bool SEAES_Framework { get; set; }
    public bool SEAES_Feedback { get; set; }
    public string? Observations { get; set; }
}