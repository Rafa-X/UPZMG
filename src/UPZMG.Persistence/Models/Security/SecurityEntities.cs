using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UPZMG.Persistence.Models.RRHH;

namespace UPZMG.Persistence.Models.Security;

public class UsuarioSistema
{
    public Guid Id { get; set; }

    public Guid? EmpleadoId { get; set; }
    public virtual Empleado? Empleado { get; set; }

    [Required]
    [MaxLength(255)]
    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public bool Activo { get; set; }

    public DateTime? UltimoAcceso { get; set; }

    public virtual ICollection<UsuarioRol> UsuarioRoles { get; set; } = new List<UsuarioRol>();
}

public class Rol
{
    public int Id { get; set; } 

    [Required]
    [MaxLength(50)]
    public string NombreRol { get; set; } = string.Empty;

    public virtual ICollection<UsuarioRol> UsuarioRoles { get; set; } = new List<UsuarioRol>();
}

public class UsuarioRol
{
    public Guid UsuarioId { get; set; }
    public virtual UsuarioSistema? Usuario { get; set; }

    public int RolId { get; set; }
    public virtual Rol? Rol { get; set; }
}

public class PermisoReporte
{
    public int Id { get; set; }

    public int RolId { get; set; }
    public virtual Rol? Rol { get; set; }

    [Required]
    [MaxLength(50)]
    public string ReporteClave { get; set; } = string.Empty;

    public bool PuedeEditar { get; set; }
    public bool PuedeFirmar { get; set; }
}
