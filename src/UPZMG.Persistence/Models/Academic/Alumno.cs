using System.ComponentModel.DataAnnotations;
using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models.Academic;

public class Alumno
{
    public Guid Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Matricula { get; set; } = string.Empty; // Unique
    
    [Required]
    [MaxLength(18)]
    public string Curp { get; set; } = string.Empty; // UNique
    
    [Required]
    [MaxLength(100)]
    public string Nombre { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(100)]
    public string PrimerApellido { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string? SegundoApellido { get; set; }
    
    public DateOnly FechaNacimiento { get; set; }
    
    public Sexo Sexo { get; set; }
    
    public bool HablaLenguaIndigena { get; set; }
    
    [MaxLength(10)]
    public string CodigoPostal { get; set; } = string.Empty;
    
    public NivelIngles NivelIngles { get; set; }
    
    public EstadoCivil EstadoCivil { get; set; }
    
    public int NumeroHijos { get; set; }
    
    public bool Trabaja { get; set; }
    
    [MaxLength(100)]
    public string LugarNacimientoPais { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string LugarNacimientoEstado { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string PaisBachillerato { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string EntidadProcedenciaBachillerato { get; set; } = string.Empty;
}
