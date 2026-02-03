using System.ComponentModel.DataAnnotations;
using UPZMG.Persistence.Models.Academic;

namespace UPZMG.Persistence.Models.Resources;

public class SeguridadProteccionCivil
{
    public int Id { get; set; }

    public int PeriodoId { get; set; }
    public virtual Periodo? Periodo { get; set; }

    public bool TieneProteccionCivil { get; set; }
    public bool TieneRutasEvacuacion { get; set; }
    public bool TieneZonasSeguridad { get; set; }

    public int AlarmasEnUso { get; set; }
    public int BotiquinesEnUso { get; set; }
    public int ExtintoresEnUso { get; set; }
    public int SenalamientosEnUso { get; set; }
}
