using System.ComponentModel.DataAnnotations;

namespace UPZMG.Persistence.Models.Catalogs;

public class CatMotivoBaja
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Descripcion { get; set; } = string.Empty;

    public bool Activo { get; set; } = true;
}
