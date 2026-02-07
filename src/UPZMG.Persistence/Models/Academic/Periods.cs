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
    public string? IdCode { get; set; }
    [MaxLength(20)]
    public string? SEP_Period { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public DateOnly StartYear { get; set; }
    public bool IsActive { get; set; }
}