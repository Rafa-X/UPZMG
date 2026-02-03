using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models.Academic;

public class KardexMateria
{
    public Guid Id { get; set; }
    
    public Guid AlumnoId { get; set; }
    public virtual Alumno? Alumno { get; set; }
    
    public int MateriaId { get; set; }
    public virtual PlanEstudiosMateria? Materia { get; set; }
    
    public int PeriodoId { get; set; }
    public virtual Periodo? Periodo { get; set; }
    
    public decimal Calificacion { get; set; }
    
    public OportunidadEvaluacion Oportunidad { get; set; }
    
    public bool Aprobada { get; set; }
}
