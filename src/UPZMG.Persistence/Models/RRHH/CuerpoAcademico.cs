using System.ComponentModel.DataAnnotations;
using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models.RRHH;

public class CuerpoAcademico
{
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string Nombre { get; set; } = string.Empty;

    public EstatusConsolidacionCA EstatusConsolidacion { get; set; }
}
