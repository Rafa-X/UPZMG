using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models;

/// <summary>
/// Academic module.
/// Represents a student's registration in a class group for a specific period.
/// </summary>

public class Registrations
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; } //fk
    public Guid GroupId { get; set; }  //fk
    public Guid PeriodId { get; set; }  //fk
    public InscriptionType InscriptionType { get; set; }
    public FinalStatus FinalStatus { get; set; }
    public Guid WithdrawReasonId { get; set; }  //fk
}