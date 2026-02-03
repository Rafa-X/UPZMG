using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UPZMG.Persistence.Models.RRHH;
using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models.Academic;

public class TramiteTitulacion
{
    public Guid Id { get; set; }

    public Guid AlumnoId { get; set; }
    public virtual Alumno? Alumno { get; set; }

    public int CarreraId { get; set; }
    public virtual Carrera? Carrera { get; set; }

    public Guid AsesorTitulacionId { get; set; }
    public virtual Empleado? AsesorTitulacion { get; set; }

    public DateOnly FechaEgresoCreditos { get; set; }
    public DateOnly? FechaActaTitulacion { get; set; }
    public DateOnly? FechaExpedicionTitulo { get; set; }

    public bool TieneCedulaProfesional { get; set; }

    public ModalidadTitulacion Modalidad { get; set; }
}
