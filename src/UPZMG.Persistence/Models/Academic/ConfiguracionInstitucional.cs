using System.ComponentModel.DataAnnotations;
using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models.Academic;

public class ConfiguracionInstitucional
{
    public int Id { get; set; }

    [MaxLength(255)]
    public string NombreInstitucion { get; set; } = string.Empty;
    [MaxLength(50)]
    public string ClaveInstitucion { get; set; } = string.Empty;
    [MaxLength(255)]
    public string NombreEscuelaCampus { get; set; } = string.Empty;
    
    [MaxLength(50)]
    public string ClaveCct { get; set; } = string.Empty;
    [MaxLength(50)]
    public string ClaveCctBiblioteca { get; set; } = string.Empty;

    [MaxLength(200)]
    public string NombreRector { get; set; } = string.Empty;

    // Enums Sostenimiento, TenenciaInmueble (definidos en CommonEnums)
    public Sostenimiento Sostenimiento { get; set; } 
    public TenenciaInmueble TenenciaInmueble { get; set; }

    [MaxLength(20)]
    public string TelefonoInstitucional { get; set; } = string.Empty;
    [MaxLength(10)]
    public string TelefonoExtension { get; set; } = string.Empty;
    [MaxLength(255)]
    public string PaginaWeb { get; set; } = string.Empty;

    [MaxLength(200)]
    public string NombreResponsable { get; set; } = string.Empty;
    [MaxLength(100)]
    public string PuestoResponsable { get; set; } = string.Empty;
    [MaxLength(200)]
    public string CorreoResponsable { get; set; } = string.Empty;

    // Address
    public string DireccionCalle { get; set; } = string.Empty;
    public string DireccionNumero { get; set; } = string.Empty;
    public string DireccionNumInt { get; set; } = string.Empty;
    public string Colonia { get; set; } = string.Empty;
    public string Localidad { get; set; } = string.Empty;
    public string Municipio { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
    public string Cp { get; set; } = string.Empty;

    public string LogoUrl { get; set; } = string.Empty;
}
