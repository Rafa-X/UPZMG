using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UPZMG.Persistence.Models.RRHH;

public class LineaInvestigacion
{
    public int Id { get; set; }

    public int CuerpoAcademicoId { get; set; }
    public virtual CuerpoAcademico? CuerpoAcademico { get; set; }

    [Required]
    [MaxLength(255)]
    public string NombreLgac { get; set; } = string.Empty;
}
