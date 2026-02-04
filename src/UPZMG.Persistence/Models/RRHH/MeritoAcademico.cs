using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models.RRHH;

public class MeritoAcademico
{
    public Guid Id { get; set; }

    public Guid EmpleadoId { get; set; }
    public virtual Empleado? Empleado { get; set; }

    public TipoMerito Tipo { get; set; }

    [MaxLength(100)]
    public string Nivel { get; set; } = string.Empty;

    public DateOnly VigenciaInicio { get; set; }
    public DateOnly? VigenciaFin { get; set; }
}
