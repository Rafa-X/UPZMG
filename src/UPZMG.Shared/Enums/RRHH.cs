namespace UPZMG.Shared.Enums;

/// <summary>
/// Represents the gender type of a student or academic.
/// </summary>
public enum GenderType
{
    H,
    M
}


/// <summary>
/// Represents the highest education level of an employee.
/// </summary>
public enum EducationLevel
{
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

/// <summary>
/// Represents the place of study for an employee's education.
/// </summary>
public enum StudyPlace
{
    Nacional,
    Extranjero
}

/// <summary>
/// Represents the type of internal area within the organization.
/// </summary>

public enum InternalAreaType
{
    AcademicaOperativa,
    AdministrativaCentral,
}

/// <summary>
/// Represents the SEP 911 category of an employee.
/// </summary>
public enum SEP_911
{
    Directivo,
    Docente,
    DocenteInvestigador,
    AuxiliarInvestigador,
    Administrativo,
    Servicios
}

/// <summary>
/// Represents the type of workday for an employee's contract.
/// </summary>
public enum WorkdayType
{
    TiempoCompleto,
    TresCuartos,
    MedioTiempo,
    Asignatura,
}

/// <summary>
/// Represents the academic tab level of an employee.
/// </summary>

public enum TabLevel
{
    TitularA,
    TitularB,
    TitularC,
    AsociadoA,
    AsociadoB,
    AsociadoC,
    TecnicoAcademico
}

/// <summary>
/// Represents the type of academic goal for employees.
/// </summary>

public enum GoalType
{
    SNI,
    PRODEP,
    Distincion,
}

/// <summary>
/// Represents the role of an employee in a CA (Académic Committee).
/// </summary>
public enum RoleCA
{
    Lider,
    Integrante,
    Colaborador
}

/// <summary>
/// Represents the status of an employee in a CA (Académic Committee).
/// </summary>
public enum StatusAC
{
    EnFormacion,
    EnConsolidacion,
    Consolidado
}