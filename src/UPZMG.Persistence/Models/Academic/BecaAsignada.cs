using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UPZMG.Persistence.Models.Catalogs;
using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models.Academic;

public class BecaAsignada
{
    public Guid Id { get; set; }

    public Guid AlumnoId { get; set; }
    public virtual Alumno? Alumno { get; set; }

    public int PeriodoId { get; set; }
    public virtual Periodo? Periodo { get; set; }

    public int ProgramaBecaId { get; set; }
    public virtual CatProgramaBeca? ProgramaBeca { get; set; }

    
    // // Enums que faltan definir tal vez, de mientras uso strings
    // public string TipoBeca { get; set; } = string.Empty; 
    // public string ObjetivoBeca { get; set; } = string.Empty;

    public TipoBeca TipoBeca { get; set; }
    public ObjetivoBeca ObjetivoBeca { get; set; }

    public FuenteFinanciamiento FuenteFinanciamiento { get; set; }

    public decimal MontoPeriodo { get; set; }
}
