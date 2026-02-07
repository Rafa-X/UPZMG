namespace UPZMG.Persistence.Models;

/// <summary>
/// Academic module.
/// Represents student's disability in the academic system.
/// </summary>

public class StudentDisabilities
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid DisabilityId { get; set; }
}