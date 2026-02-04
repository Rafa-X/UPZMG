using System.ComponentModel.DataAnnotations;

namespace UPZMG.Persistence.Models.Catalogs;

public class CatProgramaBeca
{
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string NombrePrograma { get; set; } = string.Empty;

    [MaxLength(500)]
    public string Descripcion { get; set; } = string.Empty;

    public bool Activo { get; set; } = true;
}
