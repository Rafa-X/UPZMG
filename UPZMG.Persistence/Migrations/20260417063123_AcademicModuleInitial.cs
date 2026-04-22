using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UPZMG.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AcademicModuleInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "carrers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    SEPCode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    EducationalLevel = table.Column<int>(type: "integer", nullable: false),
                    Modality = table.Column<int>(type: "integer", nullable: false),
                    PeriodType = table.Column<int>(type: "integer", nullable: false),
                    DurationInPeriods = table.Column<int>(type: "integer", nullable: false),
                    DurationInYears = table.Column<int>(type: "integer", nullable: false),
                    TotalCredits = table.Column<int>(type: "integer", nullable: false),
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
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disabilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployeeNumber = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Rfc = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    Curp = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    HighestEducationLevel = table.Column<int>(type: "integer", nullable: false),
                    TitleStatus = table.Column<int>(type: "integer", nullable: false),
                    SpeaksIndigenousLanguage = table.Column<bool>(type: "boolean", nullable: false),
                    HasDisability = table.Column<bool>(type: "boolean", nullable: false),
                    ExternalXPYears = table.Column<int>(type: "integer", nullable: false),
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
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LanguageName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndigenousLanguages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "institutionalConfigurations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PeriodId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsEvaluated = table.Column<bool>(type: "boolean", nullable: false),
                    PublicResults = table.Column<bool>(type: "boolean", nullable: false),
                    URLResults = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    SEAES_Framework = table.Column<bool>(type: "boolean", nullable: false),
                    SEAES_Feedback = table.Column<bool>(type: "boolean", nullable: false),
                    Observations = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_institutionalConfigurations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "periods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdCode = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    SEP_Period = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_periods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolFacility",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    InUse = table.Column<bool>(type: "boolean", nullable: false),
                    HasInternet = table.Column<bool>(type: "boolean", nullable: false),
                    HasComputers = table.Column<bool>(type: "boolean", nullable: false),
                    SupportDisabilities = table.Column<bool>(type: "boolean", nullable: false),
                    Problems = table.Column<List<string>>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolFacility", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScolarshipProgram",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OfficialName = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    SourceType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScolarshipProgram", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WithdrawReason",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WithdrawReason", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "asignaturesPrograms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CareerId = table.Column<Guid>(type: "uuid", nullable: false),
                    AsignatureCode = table.Column<Guid>(type: "uuid", nullable: false),
                    AsignatureName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Credits = table.Column<int>(type: "integer", nullable: false),
                    IsCoreSubject = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asignaturesPrograms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_asignaturesPrograms_carrers_CareerId",
                        column: x => x.CareerId,
                        principalTable: "carrers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EnrollmentNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CURP = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    MiddleName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    SpeaksIndigenousLanguage = table.Column<bool>(type: "boolean", nullable: false),
                    IndigenousLanguageId = table.Column<Guid>(type: "uuid", nullable: false),
                    PostalCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    EnglishLevel = table.Column<int>(type: "integer", nullable: false),
                    MaritalStatus = table.Column<int>(type: "integer", nullable: false),
                    NumberOfChildren = table.Column<int>(type: "integer", nullable: false),
                    Works = table.Column<bool>(type: "boolean", nullable: false),
                    BirthCountry = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    BirthState = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    HighSchoolCountry = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    HighSchoolEntity = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_students_IndigenousLanguages_IndigenousLanguageId",
                        column: x => x.IndigenousLanguageId,
                        principalTable: "IndigenousLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "institutionalEvaluations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PeriodId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsEvaluated = table.Column<bool>(type: "boolean", nullable: false),
                    PublicResults = table.Column<bool>(type: "boolean", nullable: false),
                    URLResults = table.Column<string>(type: "text", nullable: true),
                    SEAES_Framework = table.Column<bool>(type: "boolean", nullable: false),
                    SEAES_Feedback = table.Column<bool>(type: "boolean", nullable: false),
                    Observations = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_institutionalEvaluations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_institutionalEvaluations_periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "periods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "classGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PeriodId = table.Column<Guid>(type: "uuid", nullable: false),
                    CareerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Semester = table.Column<int>(type: "integer", nullable: false),
                    GroupIdentifier = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    TeacherId = table.Column<Guid>(type: "uuid", nullable: false),
                    FacilityId = table.Column<Guid>(type: "uuid", nullable: false),
                    MaxStudents = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_classGroups_Employee_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_classGroups_SchoolFacility_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "SchoolFacility",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_classGroups_carrers_CareerId",
                        column: x => x.CareerId,
                        principalTable: "carrers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_classGroups_periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "periods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "kardex",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    AsignatureId = table.Column<Guid>(type: "uuid", nullable: false),
                    PeriodId = table.Column<Guid>(type: "uuid", nullable: false),
                    Grade = table.Column<double>(type: "double precision", nullable: false),
                    IsPassed = table.Column<bool>(type: "boolean", nullable: false),
                    Opportunity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kardex", x => x.Id);
                    table.ForeignKey(
                        name: "FK_kardex_asignaturesPrograms_AsignatureId",
                        column: x => x.AsignatureId,
                        principalTable: "asignaturesPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_kardex_periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "periods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_kardex_students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "scolarshipAssigneds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ScolarshipProgramId = table.Column<Guid>(type: "uuid", nullable: false),
                    PeriodId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    ScolarshipObjective = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    FinantialSource = table.Column<int>(type: "integer", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_scolarshipAssigneds_periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "periods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_scolarshipAssigneds_students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "studentDisabilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    DisabilityId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentDisabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_studentDisabilities_Disabilities_DisabilityId",
                        column: x => x.DisabilityId,
                        principalTable: "Disabilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_studentDisabilities_students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "titulationProcesses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    CareerId = table.Column<Guid>(type: "uuid", nullable: false),
                    TitulationAssessorId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreditsEgressDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CertificateTitulationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    TitleExpeditionDate = table.Column<DateOnly>(type: "date", nullable: false),
                    HasProfessionalLicence = table.Column<bool>(type: "boolean", nullable: false),
                    ProfessionalLicenceNumber = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_titulationProcesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_titulationProcesses_Employee_TitulationAssessorId",
                        column: x => x.TitulationAssessorId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_titulationProcesses_carrers_CareerId",
                        column: x => x.CareerId,
                        principalTable: "carrers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_titulationProcesses_students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "academicLoads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseId = table.Column<Guid>(type: "uuid", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uuid", nullable: false),
                    FacilityId = table.Column<Guid>(type: "uuid", nullable: false),
                    WeekHours = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_academicLoads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_academicLoads_Employee_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_academicLoads_SchoolFacility_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "SchoolFacility",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_academicLoads_asignaturesPrograms_CourseId",
                        column: x => x.CourseId,
                        principalTable: "asignaturesPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_academicLoads_classGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "classGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "registrations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    PeriodId = table.Column<Guid>(type: "uuid", nullable: false),
                    InscriptionType = table.Column<int>(type: "integer", nullable: false),
                    FinalStatus = table.Column<int>(type: "integer", nullable: false),
                    WithdrawReasonId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registrations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_registrations_WithdrawReason_WithdrawReasonId",
                        column: x => x.WithdrawReasonId,
                        principalTable: "WithdrawReason",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_registrations_classGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "classGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_registrations_periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "periods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_registrations_students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tutoringSessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    SessionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TopicDiscussion = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tutoringSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tutoringSessions_classGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "classGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tutoringSessions_students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "scolarshipAssigneds");

            migrationBuilder.DropTable(
                name: "studentDisabilities");

            migrationBuilder.DropTable(
                name: "titulationProcesses");

            migrationBuilder.DropTable(
                name: "tutoringSessions");

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
