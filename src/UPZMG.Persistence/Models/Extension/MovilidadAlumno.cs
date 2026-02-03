using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UPZMG.Persistence.Models.Academic;
using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models.Extension;

public class MovilidadAlumno
{
    public Guid Id { get; set; }

    public Guid AlumnoId { get; set; }
    public virtual Alumno? Alumno { get; set; }

    public TipoMovilidad TipoMovilidad { get; set; }

    [MaxLength(255)]
    public string InstitucionPaisDestino { get; set; } = string.Empty;

    public bool TieneFinanciamiento { get; set; }
    
    public FuenteFinanciamiento FuenteFinanciamiento { get; set; }

    public bool ValorCurricular { get; set; }
}
