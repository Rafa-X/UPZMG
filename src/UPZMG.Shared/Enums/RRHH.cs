namespace UPZMG.Shared.Enums;

/// <summary>
/// Represents the type of internal area within the organization.
/// </summary>

public enum InternalAreaType
{
    NoEspecificado,

    AcademicaOperativa,
    AdministrativaCentral,
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