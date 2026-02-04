using System.ComponentModel.DataAnnotations;
using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models.Extension;

public class ServicioComunidad
{
    public int Id { get; set; }

    public int Anio { get; set; }

    public AreaAtencionServicio AreaAtencion { get; set; }

    public int TotalServicios { get; set; }
    public int TotalBeneficiarios { get; set; }
}
