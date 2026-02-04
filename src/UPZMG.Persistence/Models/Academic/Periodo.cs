using System.ComponentModel.DataAnnotations;

namespace UPZMG.Persistence.Models.Academic;

public class Periodo
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(20)]
    public string CodigoIdentificador { get; set; } = string.Empty; // Ejemplo "2024-3"
    
    [Required]
    [MaxLength(20)]
    public string CicloEscolarSep { get; set; } = string.Empty; // Ejemplo "2024-2025"
    
    public DateOnly FechaInicio { get; set; }
    
    public DateOnly FechaFin { get; set; }
    
    public bool EsActivo { get; set; }
}
