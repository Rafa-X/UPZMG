using System.ComponentModel.DataAnnotations;
using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models.Academic;

public class Carrera
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string NombreOficial { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(50)]
    public string ClaveSep { get; set; } = string.Empty;
    
    public NivelEducativo NivelEducativo { get; set; }
    
    public ModalidadEstudio Modalidad { get; set; }
    
    public TipoPeriodo TipoPeriodo { get; set; }
    
    public int DuracionPeriodos { get; set; }
    
    public decimal DuracionAnios { get; set; }
    
    public int CreditosTotales { get; set; }
    
    public DateOnly FechaCreacionPlan { get; set; }
    
    public DateOnly? FechaUltimaActualizacionPlan { get; set; }
    
    // Navigation properties se pueden añadir despues (por ejmplo, ICollection<PlanEstudiosMateria>)
}
