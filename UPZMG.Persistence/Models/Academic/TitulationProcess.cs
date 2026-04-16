using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models;

/// <summary>
/// Academic module.
/// Represents student's titulation process in the academic system.
/// </summary>

public class TitulationProcess
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; } //fk
    public Guid CareerId { get; set; } //fk
    public Guid TitulationAssessorId { get; set; } //fk
    public DateOnly CreditsEgressDate { get; set; }
    public DateOnly CertificateTitulationDate { get; set; }
    public DateOnly TitleExpeditionDate { get; set; }
    public bool HasProfessionalLicence { get; set; }
    public TitulationModality ProfessionalLicenceNumber { get; set; }
}