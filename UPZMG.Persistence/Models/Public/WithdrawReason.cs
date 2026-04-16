using System.ComponentModel.DataAnnotations;

namespace UPZMG.Persistence.Models;

/// <summary>
/// Public module.
/// Represents a reason for withdrawal in the academic system.
/// </summary>

public class WithdrawReason
{
    public Guid Id { get; set; }
    [MaxLength(100)]
    public string Description { get; set; } = null!;
}