using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UPZMG.Persistence.Models.RRHH;
using UPZMG.Persistence.Models.Resources;
using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models.Academic;

public class GrupoClase
{
    public Guid Id { get; set; } // UUID en la base de datos

    // Relación con Periodo
    public int PeriodoId { get; set; }
    public virtual Periodo? Periodo { get; set; }

    // Relación con Carrera
    public int CarreraId { get; set; }
    public virtual Carrera? Carrera { get; set; }

    public int SemestreGrado { get; set; }

    [Required]
    [MaxLength(10)]
    public string IdentificadorGrupo { get; set; } = string.Empty; // Por ejemplo... "A", "B"

    public Turno Turno { get; set; }

    public int CupoMaximo { get; set; }
    
    public Guid TutorId { get; set; }
    public virtual Empleado? Tutor { get; set; }

    public int AulaBaseId { get; set; }
    public virtual EspacioFisico? AulaBase { get; set;}
}