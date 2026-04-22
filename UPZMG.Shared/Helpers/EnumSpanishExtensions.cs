// using UPZMG.Shared.Enums;

// namespace UPZMG.Shared.Helpers;

// /// <summary>
// /// Extension methods to get Spanish descriptions for enums.
// /// </summary>

// public static class EnumSpanishExtensions
// {
//     public static string ToSpanish(this EducationLevel level) => level switch
//     {
//         EducationLevel.Preparatoria => "Preparatoria",
//         EducationLevel.TecnicoSuperior => "Técnico Superior",
//         EducationLevel.Licenciatura_Ingenieria => "Licenciatura / Ingeniería",
//         EducationLevel.Maestria => "Maestría",
//         EducationLevel.Doctorado => "Doctorado",
//         _ => "No especificado"
//     };

//     public static string ToSpanish(this TitleStatus status) => status switch
//     {
//         TitleStatus.NoIniciado => "No iniciado",
//         TitleStatus.EnTramite => "En trámite",
//         TitleStatus.Aprobado => "Aprobado",
//         TitleStatus.Titulado => "Titulado",
//         TitleStatus.Rechazado => "Rechazado",
//         _ => "No especificado"
//     };
// }

// // How to use: var text = HighestEducationLevel.Bachelor.ToSpanish();