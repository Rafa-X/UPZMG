using Microsoft.EntityFrameworkCore;
using UPZMG.Persistence.Models;
using UPZMG.Persistence.Models.Academic;
using UPZMG.Persistence.Models.Catalogs;
using UPZMG.Persistence.Models.RRHH;
using UPZMG.Persistence.Models.Resources;

using UPZMG.Persistence.Models.Extension;
using UPZMG.Persistence.Models.Finance;
using UPZMG.Persistence.Models.Security;

namespace UPZMG.Persistence;

public class DBContext : DbContext
{
    public DBContext(DbContextOptions<DBContext> options) : base(options) { }

    // Security Schema
    public DbSet<UsuarioSistema> Usuarios => Set<UsuarioSistema>();
    public DbSet<Rol> Roles => Set<Rol>();
    public DbSet<UsuarioRol> UsuarioRoles => Set<UsuarioRol>();
    public DbSet<PermisoReporte> PermisosReportes => Set<PermisoReporte>();

    // Extension Schema
    public DbSet<Convenio> Convenios => Set<Convenio>();
    public DbSet<AlumnoProyectoVinculacion> ProyectosVinculacion => Set<AlumnoProyectoVinculacion>();
    public DbSet<SeguimientoEgresados> SeguimientoEgresados => Set<SeguimientoEgresados>();
    public DbSet<MovilidadAlumno> MovilidadAlumnos => Set<MovilidadAlumno>();
    public DbSet<EducacionContinua> EducacionContinua => Set<EducacionContinua>();
    public DbSet<ServicioComunidad> ServiciosComunidad => Set<ServicioComunidad>();
    public DbSet<ProduccionEditorial> ProduccionEditorial => Set<ProduccionEditorial>();
    public DbSet<EventoExtension> EventosExtension => Set<EventoExtension>();

    // Finance Schema
    public DbSet<FinanzasAnuales> FinanzasAnuales => Set<FinanzasAnuales>();

    // Academic Schema
    public DbSet<Periodo> Periodos => Set<Periodo>();
    public DbSet<Carrera> Carreras => Set<Carrera>();
    public DbSet<PlanEstudiosMateria> Materias => Set<PlanEstudiosMateria>();
    public DbSet<Alumno> Alumnos => Set<Alumno>();
    public DbSet<GrupoClase> Grupos => Set<GrupoClase>();
    public DbSet<CargaAcademica> CargasAcademicas => Set<CargaAcademica>();
    public DbSet<InscripcionHistorial> Inscripciones => Set<InscripcionHistorial>();
    public DbSet<KardexMateria> Kardex => Set<KardexMateria>();
    public DbSet<ConfiguracionInstitucional> ConfiguracionInstitucional => Set<ConfiguracionInstitucional>();
    public DbSet<EvaluacionInstitucional> EvaluacionesInstitucionales => Set<EvaluacionInstitucional>();
    public DbSet<SesionTutoria> Tutorias => Set<SesionTutoria>();
    public DbSet<TramiteTitulacion> Titulaciones => Set<TramiteTitulacion>();
    public DbSet<BecaAsignada> Becas => Set<BecaAsignada>();

    // RRHH Schema
    public DbSet<AreaInterna> AreasInternas => Set<AreaInterna>();
    public DbSet<PuestoMapping> Puestos => Set<PuestoMapping>();
    public DbSet<Empleado> Empleados => Set<Empleado>();
    public DbSet<ContratoHistorial> Contratos => Set<ContratoHistorial>();
    public DbSet<CuerpoAcademico> CuerposAcademicos => Set<CuerpoAcademico>();
    public DbSet<LineaInvestigacion> LineasInvestigacion => Set<LineaInvestigacion>();
    public DbSet<DocenteCuerpoAcademico> DocentesCuerposAcademicos => Set<DocenteCuerpoAcademico>();
    public DbSet<MeritoAcademico> Meritos => Set<MeritoAcademico>();
    public DbSet<FormacionContinuaDocente> FormacionContinua => Set<FormacionContinuaDocente>();

    // Resources Schema
    public DbSet<EspacioFisico> EspaciosFisicos => Set<EspacioFisico>();
    public DbSet<Estacionamiento> Estacionamientos => Set<Estacionamiento>();
    public DbSet<SeguridadProteccionCivil> SeguridadProteccionCivil => Set<SeguridadProteccionCivil>();
    public DbSet<DiagnosticoInfraestructuraFisica> DiagnosticosInfraestructura => Set<DiagnosticoInfraestructuraFisica>();
    public DbSet<InventarioTicAnual> InventariosTic => Set<InventarioTicAnual>();

    // Catalogs
    public DbSet<CatPais> CatPaises => Set<CatPais>();
    public DbSet<CatLenguaIndigena> CatLenguasIndigenas => Set<CatLenguaIndigena>();
    public DbSet<CatDiscapacidad> CatDiscapacidades => Set<CatDiscapacidad>();
    public DbSet<CatProgramaBeca> CatProgramasBecas => Set<CatProgramaBeca>();
    public DbSet<CatMotivoBaja> CatMotivosBaja => Set<CatMotivoBaja>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureAcademic(modelBuilder);
        ConfigureRRHH(modelBuilder);
        ConfigureResources(modelBuilder);
        ConfigureExtension(modelBuilder);
        ConfigureFinance(modelBuilder);
        ConfigureSecurity(modelBuilder);
        ConfigureCatalogs(modelBuilder);
    }

    private void ConfigureResources(ModelBuilder modelBuilder)
    {
        // 4.1 Espacios Fisicos
        modelBuilder.Entity<EspacioFisico>(entity =>
        {
            entity.ToTable("espacios_fisicos", "recursos");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id_espacio");
            entity.Property(e => e.NombreIdentificador).HasColumnName("nombre_identificador");
            entity.Property(e => e.MetrosCuadrados).HasColumnName("metros_cuadrados");
            entity.Property(e => e.CapacidadPersonas).HasColumnName("capacidad_personas");
            entity.Property(e => e.EsAdaptado).HasColumnName("es_adaptado");
            entity.Property(e => e.EnUsoActual).HasColumnName("en_uso_actual");
            entity.Property(e => e.TieneInternet).HasColumnName("tiene_internet");
            entity.Property(e => e.TieneEquipoComputo).HasColumnName("tiene_equipo_computo");

            entity.Property(e => e.TipoUso).HasColumnName("tipo_uso").HasConversion<string>();
        });

        // 4.2 Estacionamiento
        modelBuilder.Entity<Estacionamiento>(entity =>
        {
            entity.ToTable("estacionamiento", "recursos");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id_registro");
            entity.Property(e => e.PeriodoId).HasColumnName("id_periodo");
            entity.Property(e => e.CajonesAlumnos).HasColumnName("cajones_alumnos");
            entity.Property(e => e.CajonesDocentes).HasColumnName("cajones_docentes");
            entity.Property(e => e.CajonesAdmin).HasColumnName("cajones_admin");
            entity.Property(e => e.CajonesVisitas).HasColumnName("cajones_visitas");
            entity.Property(e => e.CajonesDiscapacitados).HasColumnName("cajones_discapacitados");

            entity.HasOne(e => e.Periodo)
                  .WithMany()
                  .HasForeignKey(e => e.PeriodoId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // 4.3 Seguridad Proteccion Civil
        modelBuilder.Entity<SeguridadProteccionCivil>(entity =>
        {
            entity.ToTable("seguridad_proteccion_civil", "recursos");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id_registro");
            entity.Property(e => e.PeriodoId).HasColumnName("id_periodo");
            entity.Property(e => e.TieneProteccionCivil).HasColumnName("tiene_proteccion_civil");
            entity.Property(e => e.TieneRutasEvacuacion).HasColumnName("tiene_rutas_evacuacion");
            entity.Property(e => e.TieneZonasSeguridad).HasColumnName("tiene_zonas_seguridad");
            entity.Property(e => e.AlarmasEnUso).HasColumnName("alarmas_en_uso");
            entity.Property(e => e.BotiquinesEnUso).HasColumnName("botiquines_en_uso");
            entity.Property(e => e.ExtintoresEnUso).HasColumnName("extintores_en_uso");
            entity.Property(e => e.SenalamientosEnUso).HasColumnName("senalamientos_en_uso");

            entity.HasOne(e => e.Periodo)
                  .WithMany()
                  .HasForeignKey(e => e.PeriodoId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // 4.4 Diagnostico Infraestructura Fisica
        modelBuilder.Entity<DiagnosticoInfraestructuraFisica>(entity =>
        {
            entity.ToTable("diagnostico_infraestructura_fisica", "recursos");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id_diagnostico");
            entity.Property(e => e.PeriodoId).HasColumnName("id_periodo");
            entity.Property(e => e.PatologiasIdentificadasJson).HasColumnName("patologias_identificadas_json");
            entity.Property(e => e.ServiciosBasicosJson).HasColumnName("servicios_basicos_json");

            entity.Property(e => e.MaterialMuros).HasColumnName("material_muros").HasConversion<string>();
            entity.Property(e => e.MaterialTechos).HasColumnName("material_techos").HasConversion<string>();
            entity.Property(e => e.MaterialPisos).HasColumnName("material_pisos").HasConversion<string>();

            entity.HasOne(e => e.Periodo)
                  .WithMany()
                  .HasForeignKey(e => e.PeriodoId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // 4.5 Inventario TIC Anual
        modelBuilder.Entity<InventarioTicAnual>(entity =>
        {
            entity.ToTable("inventario_tic_anual", "recursos");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id_registro");
            entity.Property(e => e.PeriodoId).HasColumnName("id_periodo");
            entity.Property(e => e.ComputadorasOperacion).HasColumnName("computadoras_operacion");
            entity.Property(e => e.ComputadorasReparacion).HasColumnName("computadoras_reparacion");
            entity.Property(e => e.ComputadorasReserva).HasColumnName("computadoras_reserva");
            entity.Property(e => e.ComputadorasUsoAlumno).HasColumnName("computadoras_uso_alumno");
            entity.Property(e => e.ComputadorasUsoDocente).HasColumnName("computadoras_uso_docente");
            entity.Property(e => e.ComputadorasUsoAdmin).HasColumnName("computadoras_uso_admin");
            entity.Property(e => e.ComputadorasConInternet).HasColumnName("computadoras_con_internet");
            entity.Property(e => e.DetalleHardwareJson).HasColumnName("detalle_hardware_json");
            entity.Property(e => e.MotivoFallaJson).HasColumnName("motivo_falla_json");
            entity.Property(e => e.AnchoBandaMbps).HasColumnName("ancho_banda_mbps");
            entity.Property(e => e.ServidoresFisicos).HasColumnName("servidores_fisicos");
            entity.Property(e => e.ServidoresVirtuales).HasColumnName("servidores_virtuales");
            entity.Property(e => e.GradoAutomatizacionJson).HasColumnName("grado_automatizacion_json");

            entity.Property(e => e.OrigenSoftware).HasColumnName("origen_software").HasConversion<string>();

            entity.HasOne(e => e.Periodo)
                  .WithMany()
                  .HasForeignKey(e => e.PeriodoId)
                  .OnDelete(DeleteBehavior.Restrict);
        });
    }

    private void ConfigureAcademic(ModelBuilder modelBuilder)
    {
        // 2.1 Configuracion Institucional
        modelBuilder.Entity<ConfiguracionInstitucional>(entity =>
        {
            entity.ToTable("configuracion_institucional", "academic");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id_config");
            entity.Property(e => e.NombreInstitucion).HasColumnName("nombre_institucion");
            entity.Property(e => e.ClaveInstitucion).HasColumnName("clave_institucion");
            entity.Property(e => e.NombreEscuelaCampus).HasColumnName("nombre_escuela_campus");
            entity.Property(e => e.ClaveCct).HasColumnName("clave_cct");
            entity.Property(e => e.ClaveCctBiblioteca).HasColumnName("clave_cct_biblioteca");
            entity.Property(e => e.NombreRector).HasColumnName("nombre_rector");
            entity.Property(e => e.TelefonoInstitucional).HasColumnName("telefono_institucional");
            entity.Property(e => e.TelefonoExtension).HasColumnName("telefono_extension");
            entity.Property(e => e.PaginaWeb).HasColumnName("pagina_web");
            entity.Property(e => e.NombreResponsable).HasColumnName("nombre_responsable");
            entity.Property(e => e.PuestoResponsable).HasColumnName("puesto_responsable");
            entity.Property(e => e.CorreoResponsable).HasColumnName("correo_responsable");
            entity.Property(e => e.DireccionCalle).HasColumnName("direccion_calle");
            entity.Property(e => e.DireccionNumero).HasColumnName("direccion_numero");
            entity.Property(e => e.DireccionNumInt).HasColumnName("direccion_num_int");
            entity.Property(e => e.Colonia).HasColumnName("colonia");
            entity.Property(e => e.Localidad).HasColumnName("localidad");
            entity.Property(e => e.Municipio).HasColumnName("municipio");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Cp).HasColumnName("cp");
            entity.Property(e => e.LogoUrl).HasColumnName("logo_url");

            entity.Property(e => e.Sostenimiento).HasColumnName("sostenimiento").HasConversion<string>();
            entity.Property(e => e.TenenciaInmueble).HasColumnName("tenencia_inmueble").HasConversion<string>();
        });

        // 2.2 Evaluacion Institucional
        modelBuilder.Entity<EvaluacionInstitucional>(entity =>
        {
            entity.ToTable("evaluacion_institucional", "academic");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id_registro");
            entity.Property(e => e.PeriodoId).HasColumnName("id_periodo");
            entity.Property(e => e.RealizoEvaluacion).HasColumnName("realizo_evaluacion");
            entity.Property(e => e.ResultadosPublicos).HasColumnName("resultados_publicos");
            entity.Property(e => e.UrlResultados).HasColumnName("url_resultados");
            entity.Property(e => e.MarcoSeaes).HasColumnName("marco_seaes");
            entity.Property(e => e.RetroalimentacionSeaes).HasColumnName("retroalimentacion_seaes");
            entity.Property(e => e.Observaciones).HasColumnName("observaciones");

            entity.HasOne(e => e.Periodo)
                  .WithMany()
                  .HasForeignKey(e => e.PeriodoId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // 2.3 Periodos
        modelBuilder.Entity<Periodo>(entity =>
        {
            entity.ToTable("periodos", "academic");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id_periodo");
            entity.Property(e => e.CodigoIdentificador).HasColumnName("codigo_identificador");
            entity.Property(e => e.CicloEscolarSep).HasColumnName("ciclo_escolar_sep");
            entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
            entity.Property(e => e.FechaFin).HasColumnName("fecha_fin");
            entity.Property(e => e.EsActivo).HasColumnName("es_activo");
        });

        // 2.4 Carreras
        modelBuilder.Entity<Carrera>(entity =>
        {
            entity.ToTable("carreras", "academic");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id_carrera");
            entity.Property(e => e.NombreOficial).HasColumnName("nombre_oficial");
            entity.Property(e => e.ClaveSep).HasColumnName("clave_sep");
            entity.Property(e => e.DuracionPeriodos).HasColumnName("duracion_periodos");
            entity.Property(e => e.DuracionAnios).HasColumnName("duracion_anios");
            entity.Property(e => e.CreditosTotales).HasColumnName("creditos_totales");
            entity.Property(e => e.FechaCreacionPlan).HasColumnName("fecha_creacion_plan");
            entity.Property(e => e.FechaUltimaActualizacionPlan).HasColumnName("fecha_ultima_actualizacion_plan");

            // Enums conversion
            entity.Property(e => e.NivelEducativo).HasColumnName("nivel_educativo").HasConversion<string>();
            entity.Property(e => e.Modalidad).HasColumnName("modalidad").HasConversion<string>();
            entity.Property(e => e.TipoPeriodo).HasColumnName("tipo_periodo").HasConversion<string>();
        });

        // 2.5 Plan Estudios Materias
        modelBuilder.Entity<PlanEstudiosMateria>(entity =>
        {
            entity.ToTable("plan_estudios_materias", "academic");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id_materia");
            entity.Property(e => e.CarreraId).HasColumnName("id_carrera");
            entity.Property(e => e.ClaveMateria).HasColumnName("clave_materia");
            entity.Property(e => e.NombreMateria).HasColumnName("nombre_materia");
            entity.Property(e => e.CreditosSatca).HasColumnName("creditos_satca");
            entity.Property(e => e.CuatrimestreSugerido).HasColumnName("cuatrimestre_sugerido");
            entity.Property(e => e.EsTroncoComun).HasColumnName("es_tronco_comun");

            // Relationship
            entity.HasOne(e => e.Carrera)
                  .WithMany()
                  .HasForeignKey(e => e.CarreraId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // 2.6 Alumnos
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.ToTable("alumnos", "academic");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id_alumno");
            entity.Property(e => e.Matricula).HasColumnName("matricula");
            entity.Property(e => e.Curp).HasColumnName("curp");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
            entity.Property(e => e.PrimerApellido).HasColumnName("primer_apellido");
            entity.Property(e => e.SegundoApellido).HasColumnName("segundo_apellido");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.HablaLenguaIndigena).HasColumnName("habla_lengua_indigena");
            entity.Property(e => e.CodigoPostal).HasColumnName("codigo_postal");
            entity.Property(e => e.NumeroHijos).HasColumnName("numero_hijos");
            entity.Property(e => e.Trabaja).HasColumnName("trabaja");
            entity.Property(e => e.LugarNacimientoPais).HasColumnName("lugar_nacimiento_pais");
            entity.Property(e => e.LugarNacimientoEstado).HasColumnName("lugar_nacimiento_estado");
            entity.Property(e => e.PaisBachillerato).HasColumnName("pais_bachillerato");
            entity.Property(e => e.EntidadProcedenciaBachillerato).HasColumnName("entidad_procedencia_bachillerato");

            // Enums
            entity.Property(e => e.Sexo).HasColumnName("sexo").HasConversion<string>();
            entity.Property(e => e.NivelIngles).HasColumnName("nivel_ingles").HasConversion<string>();
            entity.Property(e => e.EstadoCivil).HasColumnName("estado_civil").HasConversion<string>();

            // Unique Indexes
            entity.HasIndex(e => e.Matricula).IsUnique();
            entity.HasIndex(e => e.Curp).IsUnique();
        });

        // 2.7 Grupos Clase
        modelBuilder.Entity<GrupoClase>(entity =>
        {
            entity.ToTable("grupos_clase", "academic");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id_grupo");
            entity.Property(e => e.PeriodoId).HasColumnName("id_periodo");
            entity.Property(e => e.CarreraId).HasColumnName("id_carrera");
            entity.Property(e => e.SemestreGrado).HasColumnName("semestre_grado");
            entity.Property(e => e.IdentificadorGrupo).HasColumnName("identificador_grupo");
            entity.Property(e => e.TutorId).HasColumnName("id_tutor");
            entity.Property(e => e.AulaBaseId).HasColumnName("id_aula_base");
            entity.Property(e => e.CupoMaximo).HasColumnName("cupo_maximo");

            // Enum
            entity.Property(e => e.Turno).HasColumnName("turno").HasConversion<string>();

            // Relationships
            entity.HasOne(e => e.Periodo)
                  .WithMany()
                  .HasForeignKey(e => e.PeriodoId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Carrera)
                  .WithMany()
                  .HasForeignKey(e => e.CarreraId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Tutor)
                  .WithMany()
                  .HasForeignKey(e => e.TutorId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.AulaBase)
                  .WithMany()
                  .HasForeignKey(e => e.AulaBaseId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // 2.8 Carga Academica
        modelBuilder.Entity<CargaAcademica>(entity =>
        {
            entity.ToTable("carga_academica", "academic");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id_carga");
            entity.Property(e => e.GrupoId).HasColumnName("id_grupo");
            entity.Property(e => e.MateriaId).HasColumnName("id_materia");
            entity.Property(e => e.DocenteId).HasColumnName("id_docente");
            entity.Property(e => e.EspacioEspecificoId).HasColumnName("id_espacio_especifico");
            entity.Property(e => e.HorasSemanales).HasColumnName("horas_semanales");

            entity.HasOne(e => e.Grupo)
                  .WithMany()
                  .HasForeignKey(e => e.GrupoId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Materia)
                  .WithMany()
                  .HasForeignKey(e => e.MateriaId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Docente)
                  .WithMany()
                  .HasForeignKey(e => e.DocenteId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.EspacioEspecifico)
                  .WithMany()
                  .HasForeignKey(e => e.EspacioEspecificoId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // 2.9 Inscripciones Historial
        modelBuilder.Entity<InscripcionHistorial>(entity =>
        {
            entity.ToTable("inscripciones_historial", "academic");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id_inscripcion");
            entity.Property(e => e.AlumnoId).HasColumnName("id_alumno");
            entity.Property(e => e.GrupoId).HasColumnName("id_grupo");
            entity.Property(e => e.PeriodoId).HasColumnName("id_periodo");
            entity.Property(e => e.MotivoBajaId).HasColumnName("id_motivo_baja");

            entity.Property(e => e.TipoIngreso).HasColumnName("tipo_ingreso").HasConversion<string>();
            entity.Property(e => e.EstatusFinal).HasColumnName("estatus_final").HasConversion<string>();

            entity.HasOne(e => e.Alumno)
                  .WithMany()
                  .HasForeignKey(e => e.AlumnoId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Grupo)
                  .WithMany()
                  .HasForeignKey(e => e.GrupoId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Periodo)
                  .WithMany()
                  .HasForeignKey(e => e.PeriodoId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.MotivoBaja)
                  .WithMany()
                  .HasForeignKey(e => e.MotivoBajaId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // 2.10 Kardex Materias
        modelBuilder.Entity<KardexMateria>(entity =>
        {
            entity.ToTable("kardex_materias", "academic");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id_registro");
            entity.Property(e => e.AlumnoId).HasColumnName("id_alumno");
            entity.Property(e => e.MateriaId).HasColumnName("id_materia");
            entity.Property(e => e.PeriodoId).HasColumnName("id_periodo");
            entity.Property(e => e.Calificacion).HasColumnName("calificacion");
            entity.Property(e => e.Aprobada).HasColumnName("aprobada");

            entity.Property(e => e.Oportunidad).HasColumnName("oportunidad").HasConversion<string>();

            entity.HasOne(e => e.Alumno)
                  .WithMany()
                  .HasForeignKey(e => e.AlumnoId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Materia)
                  .WithMany()
                  .HasForeignKey(e => e.MateriaId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Periodo)
                  .WithMany()
                  .HasForeignKey(e => e.PeriodoId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // 2.11 Sesiones Tutoria
        modelBuilder.Entity<SesionTutoria>(entity =>
        {
            entity.ToTable("sesiones_tutoria", "academic");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id_sesion");
            entity.Property(e => e.GrupoId).HasColumnName("id_grupo");
            entity.Property(e => e.AlumnoId).HasColumnName("id_alumno");
            entity.Property(e => e.FechaSesion).HasColumnName("fecha_sesion");
            entity.Property(e => e.TemaTratado).HasColumnName("tema_tratado");
            entity.Property(e => e.Asistio).HasColumnName("asistio");

            entity.HasOne(e => e.Grupo).WithMany().HasForeignKey(e => e.GrupoId).OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(e => e.Alumno).WithMany().HasForeignKey(e => e.AlumnoId).OnDelete(DeleteBehavior.Cascade);
        });

        // 2.12 Tramites Titulacion
        modelBuilder.Entity<TramiteTitulacion>(entity =>
        {
            entity.ToTable("tramites_titulacion", "academic");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id_tramite");
            entity.Property(e => e.AlumnoId).HasColumnName("id_alumno");
            entity.Property(e => e.CarreraId).HasColumnName("id_carrera");
            entity.Property(e => e.AsesorTitulacionId).HasColumnName("id_asesor_titulacion");
            entity.Property(e => e.FechaEgresoCreditos).HasColumnName("fecha_egreso_creditos");
            entity.Property(e => e.FechaActaTitulacion).HasColumnName("fecha_acta_titulacion");
            entity.Property(e => e.FechaExpedicionTitulo).HasColumnName("fecha_expedicion_titulo");
            entity.Property(e => e.TieneCedulaProfesional).HasColumnName("tiene_cedula_profesional");

            entity.Property(e => e.Modalidad).HasColumnName("modalidad_titulacion").HasConversion<string>();

            entity.HasOne(e => e.Alumno).WithMany().HasForeignKey(e => e.AlumnoId).OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(e => e.Carrera).WithMany().HasForeignKey(e => e.CarreraId).OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(e => e.AsesorTitulacion).WithMany().HasForeignKey(e => e.AsesorTitulacionId).OnDelete(DeleteBehavior.Restrict);
        });

        // 2.13 Becas Asignadas
        modelBuilder.Entity<BecaAsignada>(entity =>
        {
            entity.ToTable("becas_asignadas", "academic");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id_beca");
            entity.Property(e => e.AlumnoId).HasColumnName("id_alumno");
            entity.Property(e => e.PeriodoId).HasColumnName("id_periodo");
            entity.Property(e => e.ProgramaBecaId).HasColumnName("id_programa_beca");
            entity.Property(e => e.MontoPeriodo).HasColumnName("monto_periodo");

            entity.Property(e => e.TipoBeca).HasColumnName("tipo_beca").HasConversion<string>();
            entity.Property(e => e.ObjetivoBeca).HasColumnName("objetivo_beca").HasConversion<string>();
            entity.Property(e => e.FuenteFinanciamiento).HasColumnName("fuente_financiamiento").HasConversion<string>();

            entity.HasOne(e => e.Alumno).WithMany().HasForeignKey(e => e.AlumnoId).OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(e => e.Periodo).WithMany().HasForeignKey(e => e.PeriodoId).OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(e => e.ProgramaBeca).WithMany().HasForeignKey(e => e.ProgramaBecaId).OnDelete(DeleteBehavior.Restrict);
        });
    }

    private void ConfigureRRHH(ModelBuilder modelBuilder)
    {
        // 3.1 Areas Internas
        modelBuilder.Entity<AreaInterna>(entity =>
        {
            entity.ToTable("areas_internas", "rrhh");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id_area");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
            entity.Property(e => e.AreaPadreId).HasColumnName("id_area_padre");
            entity.Property(e => e.TipoArea).HasColumnName("tipo_area").HasConversion<string>();

            // Self-referencing relationship
            entity.HasOne(e => e.AreaPadre)
                  .WithMany(a => a.SubAreas)
                  .HasForeignKey(e => e.AreaPadreId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // 3.2 Puestos Mapping
        modelBuilder.Entity<PuestoMapping>(entity =>
        {
            entity.ToTable("puestos_mapping", "rrhh");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id_puesto");
            entity.Property(e => e.NombreInterno).HasColumnName("nombre_interno");
            entity.Property(e => e.CategoriaSep911).HasColumnName("categoria_sep_911").HasConversion<string>();
        });

        // 3.3 Empleados
        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.ToTable("empleados", "rrhh");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id_empleado");
            entity.Property(e => e.NumeroEmpleado).HasColumnName("numero_empleado");
            entity.Property(e => e.NombreCompleto).HasColumnName("nombre_completo");
            entity.Property(e => e.Rfc).HasColumnName("rfc");
            entity.Property(e => e.Curp).HasColumnName("curp");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.HablaLenguaIndigena).HasColumnName("habla_lengua_indigena");
            entity.Property(e => e.TieneDiscapacidad).HasColumnName("tiene_discapacidad");
            entity.Property(e => e.AniosExperienciaProfesionalExterna).HasColumnName("anios_experiencia_profesional_externa");
            entity.Property(e => e.FechaPrimerContrato).HasColumnName("fecha_primer_contrato");

            // Enums
            entity.Property(e => e.Sexo).HasColumnName("sexo").HasConversion<string>();
            entity.Property(e => e.MaximoGradoEstudios).HasColumnName("maximo_grado_estudios").HasConversion<string>();
            entity.Property(e => e.EstatusTitulacionGrado).HasColumnName("estatus_titulacion_grado").HasConversion<string>();

            // Unique indexes likely needed for RFC/CURP/NoEmpleado
            entity.HasIndex(e => e.Rfc).IsUnique();
            entity.HasIndex(e => e.Curp).IsUnique();
            entity.HasIndex(e => e.NumeroEmpleado).IsUnique();
        });

        // 3.4 Contratos Historial
        modelBuilder.Entity<ContratoHistorial>(entity =>
        {
            entity.ToTable("contratos_historial", "rrhh");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id_contrato");
            entity.Property(e => e.EmpleadoId).HasColumnName("id_empleado");
            entity.Property(e => e.PuestoId).HasColumnName("id_puesto");
            entity.Property(e => e.AreaId).HasColumnName("id_area");
            entity.Property(e => e.HorasSemanales).HasColumnName("horas_semanales");
            entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
            entity.Property(e => e.FechaFin).HasColumnName("fecha_fin");

            entity.Property(e => e.TipoTiempo).HasColumnName("tipo_tiempo").HasConversion<string>();
            entity.Property(e => e.NivelTabular).HasColumnName("nivel_tabular").HasConversion<string>();

            entity.HasOne(e => e.Empleado)
                  .WithMany()
                  .HasForeignKey(e => e.EmpleadoId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Puesto)
                  .WithMany()
                  .HasForeignKey(e => e.PuestoId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Area)
                  .WithMany()
                  .HasForeignKey(e => e.AreaId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // 3.7 Cuerpos Academicos
        modelBuilder.Entity<CuerpoAcademico>(entity =>
        {
            entity.ToTable("cuerpos_academicos", "rrhh");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id_ca");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
            entity.Property(e => e.EstatusConsolidacion).HasColumnName("estatus_consolidacion").HasConversion<string>();
        });

        // 3.8 Lineas Investigacion
        modelBuilder.Entity<LineaInvestigacion>(entity =>
        {
            entity.ToTable("lineas_investigacion", "rrhh");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id_linea");
            entity.Property(e => e.CuerpoAcademicoId).HasColumnName("id_ca");
            entity.Property(e => e.NombreLgac).HasColumnName("nombre_lgac");

            entity.HasOne(e => e.CuerpoAcademico)
                  .WithMany()
                  .HasForeignKey(e => e.CuerpoAcademicoId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // 3.9 Docente CA (Pivot)
        modelBuilder.Entity<DocenteCuerpoAcademico>(entity =>
        {
            entity.ToTable("docente_ca", "rrhh");
            entity.HasKey(e => new { e.EmpleadoId, e.CuerpoAcademicoId }); // Composite PK definition

            entity.Property(e => e.EmpleadoId).HasColumnName("id_empleado");
            entity.Property(e => e.CuerpoAcademicoId).HasColumnName("id_ca");
            entity.Property(e => e.Rol).HasColumnName("rol").HasConversion<string>();

            entity.HasOne(e => e.Empleado)
                  .WithMany()
                  .HasForeignKey(e => e.EmpleadoId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.CuerpoAcademico)
                  .WithMany()
                  .HasForeignKey(e => e.CuerpoAcademicoId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // 3.6 Meritos Academicos
        modelBuilder.Entity<MeritoAcademico>(entity =>
        {
            entity.ToTable("meritos_academicos", "rrhh");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id_merito");
            entity.Property(e => e.EmpleadoId).HasColumnName("id_empleado");
            entity.Property(e => e.Nivel).HasColumnName("nivel");
            entity.Property(e => e.VigenciaInicio).HasColumnName("vigencia_inicio");
            entity.Property(e => e.VigenciaFin).HasColumnName("vigencia_fin");

            entity.Property(e => e.Tipo).HasColumnName("tipo").HasConversion<string>();

            entity.HasOne(e => e.Empleado)
                  .WithMany()
                  .HasForeignKey(e => e.EmpleadoId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // 3.5 Formacion Continua
        modelBuilder.Entity<FormacionContinuaDocente>(entity =>
        {
            entity.ToTable("formacion_continua_docente", "rrhh");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id_registro");
            entity.Property(e => e.EmpleadoId).HasColumnName("id_empleado");
            entity.Property(e => e.TieneBeca).HasColumnName("tiene_beca");
            entity.Property(e => e.InstitucionDestino).HasColumnName("institucion_destino");

            entity.Property(e => e.NivelEstudioActual).HasColumnName("nivel_estudio_actual").HasConversion<string>();
            entity.Property(e => e.LugarEstudio).HasColumnName("lugar_estudio").HasConversion<string>();

            entity.HasOne(e => e.Empleado)
                  .WithMany()
                  .HasForeignKey(e => e.EmpleadoId)
                  .OnDelete(DeleteBehavior.Cascade);
        });
    }

    private void ConfigureExtension(ModelBuilder modelBuilder)
    {
        // 5.1 Convenios
        modelBuilder.Entity<Convenio>(entity =>
        {
            entity.ToTable("convenios", "extension");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id_convenio");
            entity.Property(e => e.NombreOrganizacion).HasColumnName("nombre_organizacion");
            entity.Property(e => e.FechaFirma).HasColumnName("fecha_firma");
            entity.Property(e => e.Estatus).HasColumnName("estatus");

            entity.Property(e => e.Sector).HasColumnName("sector").HasConversion<string>();
            entity.Property(e => e.TamanoEmpresa).HasColumnName("tamano_empresa").HasConversion<string>();
        });

        // 5.2 Alumnos Proyectos Vinculacion
        modelBuilder.Entity<AlumnoProyectoVinculacion>(entity =>
        {
            entity.ToTable("alumnos_proyectos_vinculacion", "extension");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id_proyecto");
            entity.Property(e => e.AlumnoId).HasColumnName("id_alumno");
            entity.Property(e => e.ConvenioId).HasColumnName("id_convenio");
            entity.Property(e => e.PeriodoId).HasColumnName("id_periodo");
            entity.Property(e => e.NombreProyecto).HasColumnName("nombre_proyecto");
            entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
            entity.Property(e => e.FechaFin).HasColumnName("fecha_fin");
            entity.Property(e => e.HorasAcreditadas).HasColumnName("horas_acreditadas");

            entity.Property(e => e.TipoActividad).HasColumnName("tipo_actividad").HasConversion<string>();

            entity.HasOne(e => e.Alumno).WithMany().HasForeignKey(e => e.AlumnoId).OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(e => e.Convenio).WithMany().HasForeignKey(e => e.ConvenioId).OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(e => e.Periodo).WithMany().HasForeignKey(e => e.PeriodoId).OnDelete(DeleteBehavior.Restrict);
        });

        // 5.3 Seguimiento Egresados
        modelBuilder.Entity<SeguimientoEgresados>(entity =>
        {
            entity.ToTable("seguimiento_egresados", "extension");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id_seguimiento");
            entity.Property(e => e.AlumnoId).HasColumnName("id_alumno");
            entity.Property(e => e.CarreraId).HasColumnName("id_carrera");
            entity.Property(e => e.FechaEncuesta).HasColumnName("fecha_encuesta");
            entity.Property(e => e.EstaTrabajando).HasColumnName("esta_trabajando");
            entity.Property(e => e.TrabajaEnPerfil).HasColumnName("trabaja_en_perfil");
            entity.Property(e => e.SalarioMensualAprox).HasColumnName("salario_mensual_aprox");

            entity.HasOne(e => e.Alumno).WithMany().HasForeignKey(e => e.AlumnoId).OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(e => e.Carrera).WithMany().HasForeignKey(e => e.CarreraId).OnDelete(DeleteBehavior.Restrict);
        });

        // 5.4 Movilidad Alumnos
        modelBuilder.Entity<MovilidadAlumno>(entity =>
        {
            entity.ToTable("movilidad_alumnos", "extension");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id_movilidad");
            entity.Property(e => e.AlumnoId).HasColumnName("id_alumno");
            entity.Property(e => e.InstitucionPaisDestino).HasColumnName("institucion_pais_destino");
            entity.Property(e => e.TieneFinanciamiento).HasColumnName("tiene_financiamiento");
            entity.Property(e => e.ValorCurricular).HasColumnName("valor_curricular");

            entity.Property(e => e.TipoMovilidad).HasColumnName("tipo_movilidad").HasConversion<string>();
            entity.Property(e => e.FuenteFinanciamiento).HasColumnName("fuente_financiamiento").HasConversion<string>();

            entity.HasOne(e => e.Alumno).WithMany().HasForeignKey(e => e.AlumnoId).OnDelete(DeleteBehavior.Cascade);
        });

        // 5.5 Educacion Continua
        modelBuilder.Entity<EducacionContinua>(entity =>
        {
            entity.ToTable("educacion_continua", "extension");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id_curso");
            entity.Property(e => e.NombrePrograma).HasColumnName("nombre_programa");
            entity.Property(e => e.TieneValorCurricular).HasColumnName("tiene_valor_curricular");
            entity.Property(e => e.TotalParticipantesHombres).HasColumnName("total_participantes_hombres");
            entity.Property(e => e.TotalParticipantesMujeres).HasColumnName("total_participantes_mujeres");

            entity.Property(e => e.Tipo).HasColumnName("tipo").HasConversion<string>();
        });

        // 5.6 Servicios Comunidad
        modelBuilder.Entity<ServicioComunidad>(entity =>
        {
            entity.ToTable("servicios_comunidad", "extension");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id_registro");
            entity.Property(e => e.Anio).HasColumnName("anio");
            entity.Property(e => e.TotalServicios).HasColumnName("total_servicios");
            entity.Property(e => e.TotalBeneficiarios).HasColumnName("total_beneficiarios");

            entity.Property(e => e.AreaAtencion).HasColumnName("area_atencion").HasConversion<string>();
        });

        // 5.7 Produccion Editorial
        modelBuilder.Entity<ProduccionEditorial>(entity =>
        {
            entity.ToTable("produccion_editorial", "extension");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id_produccion");
            entity.Property(e => e.Titulo).HasColumnName("titulo");
            entity.Property(e => e.EsCoedicionInternacional).HasColumnName("es_coedicion_internacional");

            entity.Property(e => e.TipoPublicacion).HasColumnName("tipo_publicacion").HasConversion<string>();
        });

        // 5.8 Eventos Extension
        modelBuilder.Entity<EventoExtension>(entity =>
        {
            entity.ToTable("eventos_extension", "extension");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id_evento");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
            entity.Property(e => e.AsistentesEstimados).HasColumnName("asistentes_estimados");

            entity.Property(e => e.Tipo).HasColumnName("tipo").HasConversion<string>();
        });
    }

    private void ConfigureFinance(ModelBuilder modelBuilder)
    {
        // 6.1 Finanzas Anuales
        modelBuilder.Entity<FinanzasAnuales>(entity =>
        {
            entity.ToTable("finanzas_anuales", "finanzas");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id_registro");
            entity.Property(e => e.AnioFiscal).HasColumnName("anio_fiscal");
            
            // Mapping decimals
            entity.Property(e => e.IngresoFederal).HasColumnName("ingreso_federal");
            entity.Property(e => e.IngresoEstatal).HasColumnName("ingreso_estatal");
            entity.Property(e => e.IngresoPropioInscripciones).HasColumnName("ingreso_propio_inscripciones");
            entity.Property(e => e.IngresoPropioServicios).HasColumnName("ingreso_propio_servicios");
            entity.Property(e => e.IngresoPropioOtros).HasColumnName("ingreso_propio_otros");
            
            entity.Property(e => e.GastoNomina).HasColumnName("gasto_nomina");
            entity.Property(e => e.GastoMateriales).HasColumnName("gasto_materiales");
            entity.Property(e => e.GastoServicios).HasColumnName("gasto_servicios");
            entity.Property(e => e.GastoInversion).HasColumnName("gasto_inversion");
            
            entity.Property(e => e.GastoFuncionalDocencia).HasColumnName("gasto_funcional_docencia");
            entity.Property(e => e.GastoFuncionalInvestigacion).HasColumnName("gasto_funcional_investigacion");
            entity.Property(e => e.GastoFuncionalExtension).HasColumnName("gasto_funcional_extension");
            entity.Property(e => e.GastoFuncionalAdmin).HasColumnName("gasto_funcional_admin");
            
            entity.Property(e => e.Observaciones).HasColumnName("observaciones");
        });
    }

    private void ConfigureSecurity(ModelBuilder modelBuilder)
    {
        // 7.1 Usuarios Sistema
        modelBuilder.Entity<UsuarioSistema>(entity =>
        {
            entity.ToTable("usuarios_sistema", "seguridad");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id_usuario");
            entity.Property(e => e.EmpleadoId).HasColumnName("id_empleado");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.PasswordHash).HasColumnName("password_hash");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.UltimoAcceso).HasColumnName("ultimo_acceso");

            entity.HasOne(e => e.Empleado)
                  .WithOne()
                  .HasForeignKey<UsuarioSistema>(e => e.EmpleadoId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // 7.2 Roles
        modelBuilder.Entity<Rol>(entity =>
        {
            entity.ToTable("roles", "seguridad");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id_rol");
            entity.Property(e => e.NombreRol).HasColumnName("nombre_rol");
        });

        // 7.3 Usuario Rol (Pivot)
        modelBuilder.Entity<UsuarioRol>(entity =>
        {
            entity.ToTable("usuario_rol", "seguridad");
            entity.HasKey(e => new { e.UsuarioId, e.RolId });
            
            entity.Property(e => e.UsuarioId).HasColumnName("id_usuario");
            entity.Property(e => e.RolId).HasColumnName("id_rol");

            entity.HasOne(e => e.Usuario).WithMany(u => u.UsuarioRoles).HasForeignKey(e => e.UsuarioId);
            entity.HasOne(e => e.Rol).WithMany(r => r.UsuarioRoles).HasForeignKey(e => e.RolId);
        });

        // 7.4 Permisos Reporte
        modelBuilder.Entity<PermisoReporte>(entity =>
        {
            entity.ToTable("permisos_reportes", "seguridad");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id_permiso");
            entity.Property(e => e.RolId).HasColumnName("id_rol");
            entity.Property(e => e.ReporteClave).HasColumnName("reporte_clave");
            entity.Property(e => e.PuedeEditar).HasColumnName("puede_editar");
            entity.Property(e => e.PuedeFirmar).HasColumnName("puede_firmar");

            entity.HasOne(e => e.Rol)
                  .WithMany()
                  .HasForeignKey(e => e.RolId)
                  .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
    
private void ConfigureCatalogs(ModelBuilder modelBuilder)
    {
        // Catalog: Paises
        modelBuilder.Entity<CatPais>(entity =>
        {
            entity.ToTable("cat_paises", "catalogs");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
            entity.Property(e => e.CodigoIso).HasColumnName("codigo_iso");
            entity.Property(e => e.Activo).HasColumnName("activo");
        });

        // Catalog: Lenguas Indigenas
        modelBuilder.Entity<CatLenguaIndigena>(entity =>
        {
            entity.ToTable("cat_lenguas_indigenas", "catalogs");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
            entity.Property(e => e.Activo).HasColumnName("activo");
        });

        // Catalog: Discapacidades
        modelBuilder.Entity<CatDiscapacidad>(entity =>
        {
            entity.ToTable("cat_discapacidades", "catalogs");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Activo).HasColumnName("activo");
        });

        // Catalog: Programas de Becas
        modelBuilder.Entity<CatProgramaBeca>(entity =>
        {
            entity.ToTable("cat_programas_becas", "catalogs");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NombrePrograma).HasColumnName("nombre_programa");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Activo).HasColumnName("activo");
        });

        // Catalog: Motivos de Baja
        modelBuilder.Entity<CatMotivoBaja>(entity =>
        {
            entity.ToTable("cat_motivos_baja", "catalogs");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Activo).HasColumnName("activo");
        });
    }
