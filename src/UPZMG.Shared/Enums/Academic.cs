namespace UPZMG.Shared.Enums;

/// <summary>
/// Represents the academic level of studies.
/// </summary>
public enum HighestEducationLevel
{
    NoEspecificado,

    Preparatoria,
    TecnicoSuperior,
    Licenciatura_Ingenieria,
    Maestria,
    Doctorado
}


/// <summary>
/// Represents the degree/title process status for a student or academic.
/// </summary>
public enum TitleStatus
{
    NoEspecificado,

    NoIniciado,
    EnTramite,
    Aprobado,
    Titulado,
    Rechazado
}

//how to use: var texto = TitleStatus.EnTramite.ToString();
