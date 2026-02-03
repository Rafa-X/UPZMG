using System.ComponentModel.DataAnnotations;
using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models.Extension;

public class Convenio
{
    public Guid Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string NombreOrganizacion { get; set; } = string.Empty;

    public SectorOrganizacion Sector { get; set; }

    public TamanoEmpresa TamanoEmpresa { get; set; }

    public DateOnly FechaFirma { get; set; }

    public bool Estatus { get; set; }
}
