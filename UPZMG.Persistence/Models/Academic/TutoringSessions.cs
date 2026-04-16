using System.ComponentModel.DataAnnotations;

namespace UPZMG.Persistence.Models;

/// <summary>
/// Academic module.
/// Represents a tutoring session in the academic system.
/// </summary>

public class TutoringSessions
{
    public Guid Id { get; set; }
    public Guid GroupId { get; set; } //fk
    public Guid StudentId { get; set; } //fk
    public DateTime SessionDate { get; set; }
    [MaxLength(250)]
    public string? TopicDiscussion { get; set; }
}