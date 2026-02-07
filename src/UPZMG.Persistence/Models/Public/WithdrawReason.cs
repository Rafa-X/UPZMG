namespace UPZMG.Persistence.Models;

/// <summary>
/// Public module.
/// Represents a reason for withdrawal in the academic system.
/// </summary>

public class WithdrawReason
{
    public Guid Id { get; set; }
    public string? Description { get; set; }
}