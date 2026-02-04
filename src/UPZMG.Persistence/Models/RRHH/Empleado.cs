using System.ComponentModel.DataAnnotations;
using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models.RRHH;

public class Empleado
{
    public Guid Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string NumeroEmpleado { get; set; } = string.Empty;

    [Required]
    [MaxLength(255)]
    public string NombreCompleto { get; set; } = string.Empty;

    [Required]
    [MaxLength(13)]
    public string Rfc { get; set; } = string.Empty;

    [Required]
    [MaxLength(18)]
    public string Curp { get; set; } = string.Empty;

    public Sexo Sexo { get; set; }

    public DateOnly FechaNacimiento { get; set; }

    public MaximoGradoEstudios MaximoGradoEstudios { get; set; }

    public EstatusTitulacionGrado EstatusTitulacionGrado { get; set; }

    public bool HablaLenguaIndigena { get; set; }

    public bool TieneDiscapacidad { get; set; }

    public int AniosExperienciaProfesionalExterna { get; set; }

    public DateOnly FechaPrimerContrato { get; set; }
}
