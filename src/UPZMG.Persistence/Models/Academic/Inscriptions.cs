using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models;

/// <summary>
/// Academic module.
/// Represents a period in the academic system.
/// </summary>

public class Inscriptions
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid GroupId { get; set; }
    public Guid PeriodId { get; set; }
    public InscriptionType InscriptionType { get; set; }
    public FinalStatus FinalStatus { get; set; }
    public DateOnly InscriptionDate { get; set; }
    public int WithdrawReason { get; set; }
}