using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UPZMG.Persistence.Models.Catalogs;
using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models.Academic;

public class InscripcionHistorial
{
    public Guid Id { get; set; }
    
    public Guid AlumnoId { get; set; }
    public virtual Alumno? Alumno { get; set; }
    
    public Guid GrupoId { get; set; }
    public virtual GrupoClase? Grupo { get; set; }
    
    public int PeriodoId { get; set; }
    public virtual Periodo? Periodo { get; set; }
    
    public TipoIngreso TipoIngreso { get; set; }
    
    public EstatusAcademic EstatusFinal { get; set; }
    
    public int? MotivoBajaId { get; set; }
    public virtual CatMotivoBaja? MotivoBaja { get; set; }
}
