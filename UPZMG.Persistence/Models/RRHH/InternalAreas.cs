using System.ComponentModel.DataAnnotations;
using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models;

/// <summary>
/// RRHH module.
/// Represents internal areas within the organization.
/// </summary>
public class InternalAreas
{
    public Guid Id { get; set; }
    [MaxLength(150)]
    public string? Name { get; set; }
    public Guid ParentAreaId { get; set; } // Self-referencing fk
    public InternalAreaType? Type { get; set; }
}