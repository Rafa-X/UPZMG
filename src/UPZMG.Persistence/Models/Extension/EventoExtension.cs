using System.ComponentModel.DataAnnotations;
using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models.Extension;

public class EventoExtension
{
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string Nombre { get; set; } = string.Empty;

    public TipoEventoExtension Tipo { get; set; }

    public int AsistentesEstimados { get; set; }
}
