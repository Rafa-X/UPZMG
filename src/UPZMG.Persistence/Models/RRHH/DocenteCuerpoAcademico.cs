using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models.RRHH;

public class DocenteCuerpoAcademico
{
    // This is a pivot table with extra columns -> Composite Key in logic, or simple ID if needed.
    // Spec doesn't specify PK explicitly but pivot tables usually have composite PK (EmpleadoId, CuerpoAcademicoId).
    // Let's use composite key mapping in FluentAPI.
    
    public Guid EmpleadoId { get; set; }
    public virtual Empleado? Empleado { get; set; }

    public int CuerpoAcademicoId { get; set; }
    public virtual CuerpoAcademico? CuerpoAcademico { get; set; }

    public RolCuerpoAcademico Rol { get; set; }
}
