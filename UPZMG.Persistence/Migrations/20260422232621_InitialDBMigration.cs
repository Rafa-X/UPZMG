using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UPZMG.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialDBMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "carrers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SEPCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EducationalLevel = table.Column<int>(type: "int", nullable: false),
                    Modality = table.Column<int>(type: "int", nullable: false),
                    PeriodType = table.Column<int>(type: "int", nullable: false),
                    DurationInPeriods = table.Column<int>(type: "int", nullable: false),
                    DurationInYears = table.Column<int>(type: "int", nullable: false),
                    TotalCredits = table.Column<int>(type: "int", nullable: false),
                    PlanCreadtedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    LastUpdatedDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carrers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Disabilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disabilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Rfc = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Curp = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    HighestEducationLevel = table.Column<int>(type: "int", nullable: false),
                    TitleStatus = table.Column<int>(type: "int", nullable: false),
                    SpeaksIndigenousLanguage = table.Column<bool>(type: "bit", nullable: false),
                    HasDisability = table.Column<bool>(type: "bit", nullable: false),
                    ExternalXPYears = table.Column<int>(type: "int", nullable: false),
                    FirstHiredDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IndigenousLanguages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndigenousLanguages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "institutionalConfigurations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsEvaluated = table.Column<bool>(type: "bit", nullable: false),
                    PublicResults = table.Column<bool>(type: "bit", nullable: false),
                    URLResults = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SEAES_Framework = table.Column<bool>(type: "bit", nullable: false),
                    SEAES_Feedback = table.Column<bool>(type: "bit", nullable: false),
                    Observations = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_institutionalConfigurations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "periods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SEP_Period = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_periods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "reportsPermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReportName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CanEdit = table.Column<bool>(type: "bit", nullable: false),
                    CanSign = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reportsPermissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolFacility",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    InUse = table.Column<bool>(type: "bit", nullable: false),
                    HasInternet = table.Column<bool>(type: "bit", nullable: false),
                    HasComputers = table.Column<bool>(type: "bit", nullable: false),
                    SupportDisabilities = table.Column<bool>(type: "bit", nullable: false),
                    Problems = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolFacility", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScolarshipProgram",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OfficialName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SourceType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScolarshipProgram", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "systemUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_systemUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WithdrawReason",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WithdrawReason", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "asignaturesPrograms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CareerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AsignatureCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AsignatureName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Credits = table.Column<int>(type: "int", nullable: false),
                    IsCoreSubject = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asignaturesPrograms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_asignaturesPrograms_carrers_CareerId",
                        column: x => x.CareerId,
                        principalTable: "carrers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnrollmentNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CURP = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    SpeaksIndigenousLanguage = table.Column<bool>(type: "bit", nullable: false),
                    IndigenousLanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    EnglishLevel = table.Column<int>(type: "int", nullable: false),
                    MaritalStatus = table.Column<int>(type: "int", nullable: false),
                    NumberOfChildren = table.Column<int>(type: "int", nullable: false),
                    Works = table.Column<bool>(type: "bit", nullable: false),
                    BirthCountry = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BirthState = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HighSchoolCountry = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HighSchoolEntity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_students_IndigenousLanguages_IndigenousLanguageId",
                        column: x => x.IndigenousLanguageId,
                        principalTable: "IndigenousLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "institutionalEvaluations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsEvaluated = table.Column<bool>(type: "bit", nullable: false),
                    PublicResults = table.Column<bool>(type: "bit", nullable: false),
                    URLResults = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SEAES_Framework = table.Column<bool>(type: "bit", nullable: false),
                    SEAES_Feedback = table.Column<bool>(type: "bit", nullable: false),
                    Observations = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_institutionalEvaluations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_institutionalEvaluations_periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "periods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "classGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CareerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: false),
                    GroupIdentifier = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    TeacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FacilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaxStudents = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_classGroups_Employee_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_classGroups_SchoolFacility_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "SchoolFacility",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_classGroups_carrers_CareerId",
                        column: x => x.CareerId,
                        principalTable: "carrers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_classGroups_periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "periods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "userRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userRoles_roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_userRoles_systemUser_UserId",
                        column: x => x.UserId,
                        principalTable: "systemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "kardex",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AsignatureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Grade = table.Column<double>(type: "float", nullable: false),
                    IsPassed = table.Column<bool>(type: "bit", nullable: false),
                    Opportunity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kardex", x => x.Id);
                    table.ForeignKey(
                        name: "FK_kardex_asignaturesPrograms_AsignatureId",
                        column: x => x.AsignatureId,
                        principalTable: "asignaturesPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_kardex_periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "periods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_kardex_students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "scolarshipAssigneds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScolarshipProgramId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScolarshipObjective = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FinantialSource = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    AssignedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scolarshipAssigneds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_scolarshipAssigneds_ScolarshipProgram_ScolarshipProgramId",
                        column: x => x.ScolarshipProgramId,
                        principalTable: "ScolarshipProgram",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_scolarshipAssigneds_periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "periods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_scolarshipAssigneds_students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "studentDisabilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisabilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentDisabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_studentDisabilities_Disabilities_DisabilityId",
                        column: x => x.DisabilityId,
                        principalTable: "Disabilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_studentDisabilities_students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "titulationProcesses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CareerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TitulationAssessorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreditsEgressDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CertificateTitulationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    TitleExpeditionDate = table.Column<DateOnly>(type: "date", nullable: false),
                    HasProfessionalLicence = table.Column<bool>(type: "bit", nullable: false),
                    ProfessionalLicenceNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_titulationProcesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_titulationProcesses_Employee_TitulationAssessorId",
                        column: x => x.TitulationAssessorId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_titulationProcesses_carrers_CareerId",
                        column: x => x.CareerId,
                        principalTable: "carrers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_titulationProcesses_students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "academicLoads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FacilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WeekHours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_academicLoads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_academicLoads_Employee_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_academicLoads_SchoolFacility_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "SchoolFacility",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_academicLoads_asignaturesPrograms_CourseId",
                        column: x => x.CourseId,
                        principalTable: "asignaturesPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_academicLoads_classGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "classGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "registrations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InscriptionType = table.Column<int>(type: "int", nullable: false),
                    FinalStatus = table.Column<int>(type: "int", nullable: false),
                    WithdrawReasonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registrations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_registrations_WithdrawReason_WithdrawReasonId",
                        column: x => x.WithdrawReasonId,
                        principalTable: "WithdrawReason",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_registrations_classGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "classGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_registrations_periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "periods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_registrations_students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "tutoringSessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SessionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TopicDiscussion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tutoringSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tutoringSessions_classGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "classGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_tutoringSessions_students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_academicLoads_CourseId",
                table: "academicLoads",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_academicLoads_FacilityId",
                table: "academicLoads",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_academicLoads_GroupId",
                table: "academicLoads",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_academicLoads_TeacherId",
                table: "academicLoads",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_asignaturesPrograms_CareerId",
                table: "asignaturesPrograms",
                column: "CareerId");

            migrationBuilder.CreateIndex(
                name: "IX_classGroups_CareerId",
                table: "classGroups",
                column: "CareerId");

            migrationBuilder.CreateIndex(
                name: "IX_classGroups_FacilityId",
                table: "classGroups",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_classGroups_PeriodId",
                table: "classGroups",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_classGroups_TeacherId",
                table: "classGroups",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_institutionalEvaluations_PeriodId",
                table: "institutionalEvaluations",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_kardex_AsignatureId",
                table: "kardex",
                column: "AsignatureId");

            migrationBuilder.CreateIndex(
                name: "IX_kardex_PeriodId",
                table: "kardex",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_kardex_StudentId",
                table: "kardex",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_registrations_GroupId",
                table: "registrations",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_registrations_PeriodId",
                table: "registrations",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_registrations_StudentId",
                table: "registrations",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_registrations_WithdrawReasonId",
                table: "registrations",
                column: "WithdrawReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_scolarshipAssigneds_PeriodId",
                table: "scolarshipAssigneds",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_scolarshipAssigneds_ScolarshipProgramId",
                table: "scolarshipAssigneds",
                column: "ScolarshipProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_scolarshipAssigneds_StudentId",
                table: "scolarshipAssigneds",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_studentDisabilities_DisabilityId",
                table: "studentDisabilities",
                column: "DisabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_studentDisabilities_StudentId",
                table: "studentDisabilities",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_students_IndigenousLanguageId",
                table: "students",
                column: "IndigenousLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_titulationProcesses_CareerId",
                table: "titulationProcesses",
                column: "CareerId");

            migrationBuilder.CreateIndex(
                name: "IX_titulationProcesses_StudentId",
                table: "titulationProcesses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_titulationProcesses_TitulationAssessorId",
                table: "titulationProcesses",
                column: "TitulationAssessorId");

            migrationBuilder.CreateIndex(
                name: "IX_tutoringSessions_GroupId",
                table: "tutoringSessions",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_tutoringSessions_StudentId",
                table: "tutoringSessions",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_userRoles_RoleId",
                table: "userRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_userRoles_UserId",
                table: "userRoles",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "academicLoads");

            migrationBuilder.DropTable(
                name: "institutionalConfigurations");

            migrationBuilder.DropTable(
                name: "institutionalEvaluations");

            migrationBuilder.DropTable(
                name: "kardex");

            migrationBuilder.DropTable(
                name: "registrations");

            migrationBuilder.DropTable(
                name: "reportsPermissions");

            migrationBuilder.DropTable(
                name: "scolarshipAssigneds");

            migrationBuilder.DropTable(
                name: "studentDisabilities");

            migrationBuilder.DropTable(
                name: "titulationProcesses");

            migrationBuilder.DropTable(
                name: "tutoringSessions");

            migrationBuilder.DropTable(
                name: "userRoles");

            migrationBuilder.DropTable(
                name: "asignaturesPrograms");

            migrationBuilder.DropTable(
                name: "WithdrawReason");

            migrationBuilder.DropTable(
                name: "ScolarshipProgram");

            migrationBuilder.DropTable(
                name: "Disabilities");

            migrationBuilder.DropTable(
                name: "classGroups");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "systemUser");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "SchoolFacility");

            migrationBuilder.DropTable(
                name: "carrers");

            migrationBuilder.DropTable(
                name: "periods");

            migrationBuilder.DropTable(
                name: "IndigenousLanguages");
        }
    }
}

