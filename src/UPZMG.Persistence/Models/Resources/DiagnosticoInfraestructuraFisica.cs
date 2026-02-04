using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UPZMG.Persistence.Models.Academic;
using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models.Resources;

public class DiagnosticoInfraestructuraFisica
{
    public int Id { get; set; }

    public int PeriodoId { get; set; }
    public virtual Periodo? Periodo { get; set; }

    public MaterialConstruccion MaterialMuros { get; set; }
    public MaterialConstruccion MaterialTechos { get; set; }
    public MaterialConstruccion MaterialPisos { get; set; }

    // JSON properties
    [Column(TypeName = "jsonb")]
    public string PatologiasIdentificadasJson { get; set; } = "{}";

    [Column(TypeName = "jsonb")]
    public string ServiciosBasicosJson { get; set; } = "{}";
}
