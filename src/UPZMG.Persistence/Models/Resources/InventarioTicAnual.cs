using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UPZMG.Persistence.Models.Academic;
using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models.Resources;

public class InventarioTicAnual
{
    public int Id { get; set; }

    public int PeriodoId { get; set; }
    public virtual Periodo? Periodo { get; set; }

    public int ComputadorasOperacion { get; set; }
    public int ComputadorasReparacion { get; set; }
    public int ComputadorasReserva { get; set; }
    public int ComputadorasUsoAlumno { get; set; }
    public int ComputadorasUsoDocente { get; set; }
    public int ComputadorasUsoAdmin { get; set; }
    public int ComputadorasConInternet { get; set; }

    [Column(TypeName = "jsonb")]
    public string DetalleHardwareJson { get; set; } = "{}";

    [Column(TypeName = "jsonb")]
    public string MotivoFallaJson { get; set; } = "{}";

    public int AnchoBandaMbps { get; set; }
    public int ServidoresFisicos { get; set; }
    public int ServidoresVirtuales { get; set; }

    [Column(TypeName = "jsonb")]
    public string GradoAutomatizacionJson { get; set; } = "{}";

    public OrigenSoftware OrigenSoftware { get; set; }
}
