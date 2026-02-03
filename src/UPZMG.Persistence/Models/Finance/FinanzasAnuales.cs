using System.ComponentModel.DataAnnotations;

namespace UPZMG.Persistence.Models.Finance;

public class FinanzasAnuales
{
    public int Id { get; set; }

    public int AnioFiscal { get; set; }

    public decimal IngresoFederal { get; set; }
    public decimal IngresoEstatal { get; set; }
    public decimal IngresoPropioInscripciones { get; set; }
    public decimal IngresoPropioServicios { get; set; }
    public decimal IngresoPropioOtros { get; set; }

    public decimal GastoNomina { get; set; }
    public decimal GastoMateriales { get; set; }
    public decimal GastoServicios { get; set; }
    public decimal GastoInversion { get; set; }

    public decimal GastoFuncionalDocencia { get; set; }
    public decimal GastoFuncionalInvestigacion { get; set; }
    public decimal GastoFuncionalExtension { get; set; }
    public decimal GastoFuncionalAdmin { get; set; }

    public string Observaciones { get; set; } = string.Empty;
}
