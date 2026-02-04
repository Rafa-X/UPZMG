using System.ComponentModel.DataAnnotations;
using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models.Extension;

public class EducacionContinua
{
    public Guid Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string NombrePrograma { get; set; } = string.Empty;

    public TipoCursoExtension Tipo { get; set; }

    public bool TieneValorCurricular { get; set; }

    public int TotalParticipantesHombres { get; set; }
    public int TotalParticipantesMujeres { get; set; }
}
