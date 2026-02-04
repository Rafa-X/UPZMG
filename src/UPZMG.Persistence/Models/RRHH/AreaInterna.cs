using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models.RRHH;

public class AreaInterna
{
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string Nombre { get; set; } = string.Empty;

    public int? AreaPadreId { get; set; }
    public virtual AreaInterna? AreaPadre { get; set; }
    
    // Recursive collection
    public virtual ICollection<AreaInterna> SubAreas { get; set; } = new List<AreaInterna>();

    public TipoArea TipoArea { get; set; }
}
