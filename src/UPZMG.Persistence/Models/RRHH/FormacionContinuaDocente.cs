using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models.RRHH;

public class FormacionContinuaDocente
{
    public Guid Id { get; set; }

    public Guid EmpleadoId { get; set; }
    public virtual Empleado? Empleado { get; set; }

    public NivelEstudioActual NivelEstudioActual { get; set; }

    public LugarEstudio LugarEstudio { get; set; }

    public bool TieneBeca { get; set; }

    [MaxLength(255)]
    public string InstitucionDestino { get; set; } = string.Empty;
}
