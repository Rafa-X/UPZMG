using UPZMG.Shared.Enums;

namespace UPZMG.Shared.Helpers;

/// <summary>
/// Extension methods to get Spanish descriptions for enums.
/// </summary>

public static class EnumSpanishExtensions
{
    public static string ToSpanish(this HighestEducationLevel level) => level switch
    {
        HighestEducationLevel.Preparatoria => "Preparatoria",
        HighestEducationLevel.TecnicoSuperior => "Técnico Superior",
        HighestEducationLevel.Licenciatura_Ingenieria => "Licenciatura / Ingeniería",
        HighestEducationLevel.Maestria => "Maestría",
        HighestEducationLevel.Doctorado => "Doctorado",
        _ => "No especificado"
    };

    public static string ToSpanish(this TitleStatus status) => status switch
    {
        TitleStatus.NoIniciado => "No iniciado",
        TitleStatus.EnTramite => "En trámite",
        TitleStatus.Aprobado => "Aprobado",
        TitleStatus.Titulado => "Titulado",
        TitleStatus.Rechazado => "Rechazado",
        _ => "No especificado"
    };
}

// How to use: var text = HighestEducationLevel.Bachelor.ToSpanish();