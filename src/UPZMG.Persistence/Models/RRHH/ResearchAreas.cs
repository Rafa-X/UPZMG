namespace UPZMG.Persistence.Models;

/// <summary>
/// RRHH module.
/// Represents research areas associated with the Academic Committee (AC).
/// </summary>

public class ResearchAreas
{
    public Guid Id { get; set; }
    public Guid AC_Id { get; set; }
    public string? AreaName { get; set; }
}