namespace UPZMG.Persistence.Models;

/// <summary>
/// Security module.
/// Represents internal areas within the organization.
/// </summary>
public class InternalAreas
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public Guid ParentAreaId { get; set; }
    public string Type { get; set; } = null!;
}