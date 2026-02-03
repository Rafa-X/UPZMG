using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UPZMG.Persistence.Models.Academic;

public class PlanEstudiosMateria
{
    public int Id { get; set; }
    
    public int CarreraId { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string ClaveMateria { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(255)]
    public string NombreMateria { get; set; } = string.Empty;
    
    public int CreditosSatca { get; set; }
    
    public int CuatrimestreSugerido { get; set; }
    
    public bool EsTroncoComun { get; set; }
    
    [ForeignKey("CarreraId")]
    public Carrera? Carrera { get; set; }
}
