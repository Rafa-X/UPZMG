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


/// <summary>
/// Represents the gender type of a student or academic.
/// </summary>
public enum GenderType
{
    H,
    M
}


/// <summary>
/// Represents marital status options.
/// </summary>
public enum MaritalStatus
{
    Soltero,
    Casado,
    UnionLibre,
    Divorciado,
    Viudo,
}

/// <summary>
/// Represents English proficiency levels.
/// </summary>
public enum EnglishLevel
{
    A1,
    A2,
    B1,
    B2,
    C1,
    C2
}