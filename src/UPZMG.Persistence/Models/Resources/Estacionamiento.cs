using System.ComponentModel.DataAnnotations;
using UPZMG.Persistence.Models.Academic; // For Periodo

namespace UPZMG.Persistence.Models.Resources;

public class Estacionamiento
{
    public int Id { get; set; }

    public int PeriodoId { get; set; }
    public virtual Periodo? Periodo { get; set; }

    public int CajonesAlumnos { get; set; }
    public int CajonesDocentes { get; set; }
    public int CajonesAdmin { get; set; }
    public int CajonesVisitas { get; set; }
    public int CajonesDiscapacitados { get; set; }
}
