using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UPZMG.Persistence.Models.Academic;

public class EvaluacionInstitucional
{
    public int Id { get; set; }

    public int PeriodoId { get; set; }
    public virtual Periodo? Periodo { get; set; }

    public bool RealizoEvaluacion { get; set; }
    public bool ResultadosPublicos { get; set; }
    public string UrlResultados { get; set; } = string.Empty;

    public bool MarcoSeaes { get; set; }
    public bool RetroalimentacionSeaes { get; set; }
    public string Observaciones { get; set; } = string.Empty;
}
