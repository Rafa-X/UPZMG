using System.ComponentModel.DataAnnotations;
using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models.RRHH;

public class PuestoMapping
{
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string NombreInterno { get; set; } = string.Empty;

    public CategoriaPuesto CategoriaSep911 { get; set; }
}
