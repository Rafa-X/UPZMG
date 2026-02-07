namespace UPZMG.Persistence.Models;

/// <summary>
/// Academic module.
/// Represents an institutional evaluation in the academic system.
/// </summary>

public class InstitutionalEvaluation
{
    public Guid Id { get; set; }
    public Guid PeriodId { get; set; }
    public bool IsEvaluated { get; set; }
    public bool PublicResults { get; set; }
    public string? URLResults { get; set; }
    public bool SEAES_Framework { get; set; }
    public bool SEAES_Feedback { get; set; }
    public string? Observations { get; set; }
}