using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models.RRHH;

public class ContratoHistorial
{
    public Guid Id { get; set; }

    public Guid EmpleadoId { get; set; }
    public virtual Empleado? Empleado { get; set; }

    public int PuestoId { get; set; }
    public virtual PuestoMapping? Puesto { get; set; }

    public int AreaId { get; set; }
    public virtual AreaInterna? Area { get; set; }

    public TipoTiempoContrato TipoTiempo { get; set; }

    public NivelTabular NivelTabular { get; set; } // O string si se prefiere libertad

    public int HorasSemanales { get; set; }

    public DateOnly FechaInicio { get; set; }
    public DateOnly? FechaFin { get; set; }
}
