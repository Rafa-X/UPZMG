namespace UPZMG.Shared.Enums;

/// <summary>
/// Educational services offered in the university.
/// </summary>
public enum EducationServicesList
{
    Inicial,
    Preescolar,
    Primaria,
    Secundaria,
    CapacitacionParaTrabajo,
    BachilleratoGeneral,
    BachilleratoTecnologico,
    TecnicoProfesional,
    LicenciaturaTSU,
    Posgrado
}

/// <summary>
/// Types of use for physical spaces.
/// </summary>
public enum SchoolFacilityType
{
    Direccion,
    ServiciosEscolares,
    ServicioMedico,
    Biblioteca,
    CanchaDeportiva,
    AreasVerdes,
    GimnasioAlberca,
    OficinaViolenciaGenero,
    CafeteriaComedor,
    TallerLaboratorio,
    AlbergueAlumnos,
    Aula,
    Auditorio,
    Oficina,
    Bodega
}

/// <summary>
/// Types of educational spaces in the university.
/// </summary>
public enum EducationalSpaceType
{
    CubiculoSalonProfesores,
    Auditorio,
    AulaActividadesArtisticas,
    AulaAudiovisual,
    Estacionamientos
}

/// <summary>
/// Types of use for physical spaces.
/// </summary>
public enum BasicServicesTypes
{
    Agua,
    AguaPotable,
    AlmacenamientoAgua,
    Electricidad,
    Gas,
    Drenaje,
    SeparacionLluviaDrenaje,
    Baños,
    Computadoras,
    Internet,
}

/// <summary>
/// Ranges of antiquity years for physical spaces.
/// </summary>
public class PropertyAntiquity
{
    public double Min { get; set; }
    public double Max { get; set; }
}

/// <summary>
/// Ranges of square meters for physical spaces.
/// </summary>
public class SquareMeters
{
    public double Min { get; set; }
    public double Max { get; set; }
}


/// <summary>
/// Problems that can be present in physical spaces.
/// </summary>
public enum PhysicalSpaceProblems
{
    DesprendimientoMaterial,
    VarillasExpuestas,
    DesperfectosCanceleria,
    DesperfectosVentanas,
    DesperfectosPuertas,
    Filtraciones,
    FlexionesTecho,
    FisurasColumnas,
    FisurasTechosMuros,
    ProblemasInstalacionElectrica,
    ProblemasInstalacionHidraulicaSanitaria,
    ProblemaRedVozDatos,
    Humedad,
    HundimientoPisos,
    LuminariasDañadas,
    MovimientoMuros,
    EdificioSeInunda,
    ProblemaAireAcondicionado,
    PisosFisurados,
    VibracionCirculacionEscaleraTecho
}

public enum ComputersUseType
{
    EnOperacion,
    EnReparacion,
    GuardadasOReserva,
    EnUsoEstudiantes,
    EnUsoDocentes,
    EnUsoPersonal,
    ConInternet
}

public enum ResourceUsedBy
{
    Educativo,
    Administrativo,
    Docente
}