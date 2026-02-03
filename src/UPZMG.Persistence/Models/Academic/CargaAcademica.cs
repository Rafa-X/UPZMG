using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UPZMG.Persistence.Models.RRHH;
using UPZMG.Persistence.Models.Resources;
using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models.Academic;

public class CargaAcademica
{
    public Guid Id { get; set; }
    
    public Guid GrupoId { get; set; }
    public virtual GrupoClase? Grupo { get; set; }
    
    public int MateriaId { get; set; }
    public virtual PlanEstudiosMateria? Materia { get; set; }
    
    // Relacion a Docente (RRHH) 
    public Guid DocenteId { get; set; }
    public virtual Empleado? Docente { get; set; }
    
    // Relacion a espacio especifico (Recursos) 
    public int? EspacioEspecificoId { get; set; }
    public virtual EspacioFisico? EspacioEspecifico { get; set; }
    
    public int HorasSemanales { get; set; }
}
