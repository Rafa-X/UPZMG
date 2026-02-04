using System.ComponentModel.DataAnnotations;
using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models.Extension;

public class ProduccionEditorial
{
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string Titulo { get; set; } = string.Empty;

    public TipoPublicacion TipoPublicacion { get; set; }

    public bool EsCoedicionInternacional { get; set; }
}
