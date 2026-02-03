using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UPZMG.Persistence.Models.Academic;

public class SesionTutoria
{
    public Guid Id { get; set; }

    public Guid GrupoId { get; set; }
    public virtual GrupoClase? Grupo { get; set; }

    public Guid AlumnoId { get; set; }
    public virtual Alumno? Alumno { get; set; }

    public DateOnly FechaSesion { get; set; }
    public string TemaTratado { get; set; } = string.Empty;
    public bool Asistio { get; set; }
}
