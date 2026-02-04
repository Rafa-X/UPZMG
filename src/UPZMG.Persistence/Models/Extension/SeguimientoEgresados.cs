using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UPZMG.Persistence.Models.Academic;

namespace UPZMG.Persistence.Models.Extension;

public class SeguimientoEgresados
{
    public Guid Id { get; set; }

    public Guid AlumnoId { get; set; }
    public virtual Alumno? Alumno { get; set; }

    public int CarreraId { get; set; }
    public virtual Carrera? Carrera { get; set; }

    public DateOnly FechaEncuesta { get; set; }

    public bool EstaTrabajando { get; set; }
    public bool TrabajaEnPerfil { get; set; }

    public decimal SalarioMensualAprox { get; set; }
}
