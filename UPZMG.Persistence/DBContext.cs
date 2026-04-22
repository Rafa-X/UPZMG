using Microsoft.EntityFrameworkCore;
using UPZMG.Persistence.Models;

namespace UPZMG.Persistence;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

    // Security
    public DbSet<SystemUser> SystemUsers => Set<SystemUser>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<UserRole> UserRoles => Set<UserRole>();
    public DbSet<ReportsPermission> ReportsPermissions => Set<ReportsPermission>();

    // Academic
    public DbSet<AcademicLoad> AcademicLoads => Set<AcademicLoad>();
    public DbSet<Carrers> Carrers => Set<Carrers>();
    public DbSet<ClassGroups> ClassGroups => Set<ClassGroups>();
    public DbSet<AsignaturesProgram> CoursesPrograms => Set<AsignaturesProgram>();
    public DbSet<InstitutionalConfiguration> InstitutionalConfigurations => Set<InstitutionalConfiguration>();
    public DbSet<InstitutionalEvaluation> InstitutionalEvaluations => Set<InstitutionalEvaluation>();
    public DbSet<Kardex> Kardexes => Set<Kardex>();
    public DbSet<Periods> Periods => Set<Periods>();
    public DbSet<AsignatureRegistrations> Registrations => Set<AsignatureRegistrations>();
    public DbSet<ScolarshipAssigned> ScolarshipAssigneds => Set<ScolarshipAssigned>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<StudentDisabilities> StudentDisabilities => Set<StudentDisabilities>();
    public DbSet<TitulationProcess> TitulationProcesses => Set<TitulationProcess>();
    public DbSet<TutoringSessions> TutoringSessions => Set<TutoringSessions>();

    // // Extension
    // public DbSet<ContinuousEducation> ContinuousEducations => Set<ContinuousEducation>();

    // // Identification
    // public DbSet<School> Schools => Set<School>();

    // // Public
    // public DbSet<Disabilities> Disabilities => Set<Disabilities>();
    // public DbSet<ScolarshipProgram> ScolarshipPrograms => Set<ScolarshipProgram>();
    // public DbSet<WithdrawReason> WithdrawReasons => Set<WithdrawReason>();
    //public DbSet<IndigenousLanguages> IndigenousLanguages => Set<IndigenousLanguages>();

    // // Resources
    // public DbSet<AnnualTICInventory> AnnualTICInventories => Set<AnnualTICInventory>();
    // public DbSet<Infraestructure> Infraestructures => Set<Infraestructure>();
    // public DbSet<ParkingLots> ParkingLots => Set<ParkingLots>();
    // public DbSet<SchoolFacility> SchoolFacilities => Set<SchoolFacility>();

    // // RRHH
    // public DbSet<AcademicGoals> AcademicGoals => Set<AcademicGoals>();
    // public DbSet<AcademicStaff> AcademicStaffs => Set<AcademicStaff>();
    // public DbSet<ASTeacher> ASTeachers => Set<ASTeacher>();
    // public DbSet<Contracts> Contracts => Set<Contracts>();
    // public DbSet<Employee> Employees => Set<Employee>();
    // public DbSet<InternalAreas> InternalAreas => Set<InternalAreas>();
    // public DbSet<PositionsMapping> PositionsMappings => Set<PositionsMapping>();
    // public DbSet<ResearchAreas> ResearchAreas => Set<ResearchAreas>();
    // public DbSet<TeacherContinuousEducation> TeacherContinuousEducations => Set<TeacherContinuousEducation>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Table mappings, keys and relationships structure (if has any)

        // Security
        modelBuilder.Entity<SystemUser>(entity => {
            entity.ToTable("systemUser");
            entity.HasKey(x => x.Id);
        });
        modelBuilder.Entity<Role>(entity => {
            entity.ToTable("roles");
            entity.HasKey(x => x.Id);
        });
        modelBuilder.Entity<UserRole>(entity => {
            entity.ToTable("userRoles");
            entity.HasKey(x => x.Id);
            entity.HasOne<SystemUser>()
                .WithMany()
                .HasForeignKey(x => x.UserId);
            entity.HasOne<Role>()
                .WithMany()
                .HasForeignKey(x => x.RoleId);
        });
        modelBuilder.Entity<ReportsPermission>(entity => {
            entity.ToTable("reportsPermissions");
            entity.HasKey(x => x.Id);
        });

        // Academic
        modelBuilder.Entity<AcademicLoad>(entity => {
            entity.ToTable("academicLoads");
            entity.HasKey(x => x.Id);
            entity.HasOne<ClassGroups>()
                .WithMany()
                .HasForeignKey(x => x.GroupId);
            entity.HasOne<AsignaturesProgram>()
                .WithMany()
                .HasForeignKey(x => x.CourseId);
            entity.HasOne<Employee>()
                .WithMany()
                .HasForeignKey(x => x.TeacherId);
            entity.HasOne<SchoolFacility>()
                .WithMany()
                .HasForeignKey(x => x.FacilityId);
        });
        modelBuilder.Entity<Carrers>(entity => {
            entity.ToTable("carrers");
            entity.HasKey(x => x.Id);
        });
        modelBuilder.Entity<ClassGroups>(entity => {
            entity.ToTable("classGroups");
            entity.HasKey(x => x.Id);
            entity.HasOne<Periods>()
                .WithMany()
                .HasForeignKey(x => x.PeriodId);
            entity.HasOne<Carrers>()
                .WithMany()
                .HasForeignKey(x => x.CareerId);
            entity.HasOne<Employee>()
                .WithMany()
                .HasForeignKey(x => x.TeacherId);
            entity.HasOne<SchoolFacility>()
                .WithMany()
                .HasForeignKey(x => x.FacilityId);
        });
        modelBuilder.Entity<AsignaturesProgram>(entity => {
            entity.ToTable("asignaturesPrograms");
            entity.HasKey(x => x.Id);
            entity.HasOne<Carrers>()
                .WithMany()
                .HasForeignKey(x => x.CareerId);
        });
        modelBuilder.Entity<InstitutionalConfiguration>(entity => {
            entity.ToTable("institutionalConfigurations");
            entity.HasKey(x => x.Id);
        });
        modelBuilder.Entity<InstitutionalEvaluation>(entity => {
            entity.ToTable("institutionalEvaluations");
            entity.HasKey(x => x.Id);
            entity.HasOne<Periods>()
                .WithMany()
                .HasForeignKey(x => x.PeriodId);
        });
        modelBuilder.Entity<Kardex>(entity => {
            entity.ToTable("kardex");
            entity.HasKey(x => x.Id);
            entity.HasOne<Student>()
                .WithMany()
                .HasForeignKey(x => x.StudentId);
            entity.HasOne<AsignaturesProgram>()
                .WithMany()
                .HasForeignKey(x => x.AsignatureId);
            entity.HasOne<Periods>()
                .WithMany()
                .HasForeignKey(x => x.PeriodId);
        });
        modelBuilder.Entity<Periods>(entity => {
            entity.ToTable("periods");
            entity.HasKey(x => x.Id);
        });
        modelBuilder.Entity<AsignatureRegistrations>(entity =>{
            entity.ToTable("registrations");
            entity.HasKey(x => x.Id);
            entity.HasOne<Student>()
                .WithMany()
                .HasForeignKey(x => x.StudentId);
            entity.HasOne<ClassGroups>()
                .WithMany()
                .HasForeignKey(x => x.GroupId);
            entity.HasOne<Periods>()
                .WithMany()
                .HasForeignKey(x => x.PeriodId);
            entity.HasOne<WithdrawReason>()
                .WithMany()
                .HasForeignKey(x => x.WithdrawReasonId);
        });
        modelBuilder.Entity<ScolarshipAssigned>(entity => {
            entity.ToTable("scolarshipAssigneds");
            entity.HasKey(x => x.Id);
            entity.HasOne<Student>()
                .WithMany()
                .HasForeignKey(x => x.StudentId);
            entity.HasOne<Periods>()
                .WithMany()
                .HasForeignKey(x => x.PeriodId);
             entity.HasOne<ScolarshipProgram>()
                .WithMany()
                .HasForeignKey(x => x.ScolarshipProgramId);
        });
        modelBuilder.Entity<Student>(entity => {
            entity.ToTable("students");
            entity.HasKey(x => x.Id);
            entity.HasOne<IndigenousLanguages>()
                .WithMany()
                .HasForeignKey(x => x.IndigenousLanguageId);
        });
        modelBuilder.Entity<StudentDisabilities>(entity => {
            entity.ToTable("studentDisabilities");
            entity.HasKey(x => x.Id);
            entity.HasOne<Student>()
                .WithMany()
                .HasForeignKey(x => x.StudentId);
            entity.HasOne<Disabilities>()
                .WithMany()
                .HasForeignKey(x => x.DisabilityId);
        });
        modelBuilder.Entity<TitulationProcess>(entity => {
            entity.ToTable("titulationProcesses");
            entity.HasKey(x => x.Id);
            entity.HasOne<Student>()
                .WithMany()
                .HasForeignKey(x => x.StudentId);
            entity.HasOne<Carrers>()
                .WithMany()
                .HasForeignKey(x => x.CareerId);
            entity.HasOne<Employee>()
                .WithMany()
                .HasForeignKey(x => x.TitulationAssessorId);
        });
        modelBuilder.Entity<TutoringSessions>(entity => {
            entity.ToTable("tutoringSessions");
            entity.HasKey(x => x.Id);
            entity.HasOne<Student>()
                .WithMany()
                .HasForeignKey(x => x.StudentId);
             entity.HasOne<ClassGroups>()
                .WithMany()
                .HasForeignKey(x => x.GroupId);
        });

        // // Extension
        // modelBuilder.Entity<ContinuousEducation>(entity => {
        //     entity.ToTable("continuousEducations");
        //     entity.HasKey(x => x.Id);
        // });

        // // Identification
        // modelBuilder.Entity<School>(entity => {
        //     entity.ToTable("schools");
        //     entity.HasKey(x => x.Id);
        // });

        // // Public
        // modelBuilder.Entity<Disabilities>(entity => {
        //     entity.ToTable("disabilities");
        //     entity.HasKey(x => x.Id);
        // });
        // modelBuilder.Entity<ScolarshipProgram>(entity => {
        //     entity.ToTable("scolarshipPrograms");
        //     entity.HasKey(x => x.Id);
        // });
        // modelBuilder.Entity<WithdrawReason>(entity => {
        //     entity.ToTable("withdrawReasons");
        //     entity.HasKey(x => x.Id);
        // });

        // // Resources
        // modelBuilder.Entity<AnnualTICInventory>(entity => {
        //     entity.ToTable("annualTICInventories");
        //     entity.HasKey(x => x.Id);
        // });
        // modelBuilder.Entity<Infraestructure>(entity => {
        //     entity.ToTable("infraestructures");
        //     entity.HasKey(x => x.Id);
        // });
        // modelBuilder.Entity<ParkingLots>(entity => {
        //     entity.ToTable("parkingLots");
        //     entity.HasKey(x => x.Id);
        // });
        // modelBuilder.Entity<SchoolFacility>(entity => {
        //     entity.ToTable("schoolFacilities");
        //     entity.HasKey(x => x.Id);
        // });

        // // RRHH
        // modelBuilder.Entity<AcademicGoals>(entity => {
        //     entity.ToTable("academicGoals");
        //     entity.HasKey(x => x.Id);
        // });
        // modelBuilder.Entity<AcademicStaff>(entity => {
        //     entity.ToTable("academicStaffs");
        //     entity.HasKey(x => x.Id);
        // });
        // modelBuilder.Entity<ASTeacher>(entity => {
        //     entity.ToTable("asTeachers");
        //     entity.HasKey(x => x.Id);
        // });
        // modelBuilder.Entity<Contracts>(entity => {
        //     entity.ToTable("contracts");
        //     entity.HasKey(x => x.Id);
        // });
        // modelBuilder.Entity<Employee>(entity => {
        //     entity.ToTable("employees");
        //     entity.HasKey(x => x.Id);
        // });
        // modelBuilder.Entity<InternalAreas>(entity => {
        //     entity.ToTable("internalAreas");
        //     entity.HasKey(x => x.Id);
        // });
        // modelBuilder.Entity<PositionsMapping>(entity => {
        //     entity.ToTable("positionsMappings");
        //     entity.HasKey(x => x.Id);
        // });
        // modelBuilder.Entity<ResearchAreas>(entity => {
        //     entity.ToTable("researchAreas");
        //     entity.HasKey(x => x.Id);
        // });
        // modelBuilder.Entity<TeacherContinuousEducation>(entity => {
        //     entity.ToTable("teacherContinuousEducations");
        //     entity.HasKey(x => x.Id);
        // });
    }
}

/*
HasOne<T>()	        “belongs to one”
WithMany()	        “one has many”
HasForeignKey()	    FOREIGN KEY column
HasKey()	        PRIMARY KEY
*/