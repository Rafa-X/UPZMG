using System.ComponentModel.DataAnnotations;
using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models.Resources;

public class EspacioFisico
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string NombreIdentificador { get; set; } = string.Empty;

    public TipoUsoEspacio TipoUso { get; set; }

    public decimal MetrosCuadrados { get; set; }

    public int CapacidadPersonas { get; set; }

    public bool EsAdaptado { get; set; }

    public bool EnUsoActual { get; set; }

    public bool TieneInternet { get; set; }

    public bool TieneEquipoComputo { get; set; }
}
