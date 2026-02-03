using System.ComponentModel.DataAnnotations;

namespace UPZMG.Persistence.Models.Catalogs;

public class CatPais
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Nombre { get; set; } = string.Empty;

    [MaxLength(3)]
    public string CodigoIso { get; set; } = string.Empty;

    public bool Activo { get; set; } = true;
}
