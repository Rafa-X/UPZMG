using System.ComponentModel.DataAnnotations;

namespace UPZMG.Persistence.Models;

/// <summary>
/// Academic module.
/// Represents a period in the academic system.
/// </summary>

public class Periods
{
    public Guid Id { get; set; }
    [MaxLength(20)]
    public string IdCode { get; set; } = null!;
    [MaxLength(20)]
    public string SEP_Period { get; set; } = null!;
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public bool IsActive { get; set; }
}