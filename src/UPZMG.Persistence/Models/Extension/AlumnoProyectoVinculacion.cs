using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UPZMG.Persistence.Models.Academic;
using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models.Extension;

public class AlumnoProyectoVinculacion
{
    public Guid Id { get; set; }

    public Guid AlumnoId { get; set; }
    public virtual Alumno? Alumno { get; set; }

    public Guid ConvenioId { get; set; }
    public virtual Convenio? Convenio { get; set; }

    public int PeriodoId { get; set; }
    public virtual Periodo? Periodo { get; set; }

    public TipoActividadVinculacion TipoActividad { get; set; }

    [MaxLength(255)]
    public string NombreProyecto { get; set; } = string.Empty;

    public DateOnly FechaInicio { get; set; }
    public DateOnly FechaFin { get; set; }

    public int HorasAcreditadas { get; set; }
}
