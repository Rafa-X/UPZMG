using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models;

/// <summary>
/// Academic module.
/// Represents a school as a entity, contains identification and education details
/// </summary>

public class School
{
    public Guid Id {get; set; }
    public EntityIdentificacion Identification { get; set; } = null!;
    public StaffInformation StaffInformation { get; set; } = null!;  //1-3, 5-6
    public TeachingLevelsGender TeachingLevelsGender { get; set; } = null!;  //4
    public Dictionary<EducationLevel, TeachersStudying> TeachersCurrentlyStudying { get; set; } = null!; //7
    public List<ExchangePrograms> ExchangePrograms { get; set; } = null!; //8
    public List<StudentsByCarrers> StudentsByCarrers { get; set; } = null!; //II - 1
    public List<StudentsScolarship> StudentsScolarship { get; set; } = null!; //II - 2
    public StaffInformation StaffSchoolModality { get; set; } = null!;  //III-1
}



#region Identification
[Owned]
public class EntityIdentificacion
{
    public int InstitutionId { get; set; }
    public int SchoolId { get; set; }
    [MaxLength(50)]
    public string? Name { get; set; }
    public string? StreetPrincipal { get; set; }
    public int NumberExt { get; set; }
    public int NumberInt { get; set; }
    public string? StreetLeft { get; set; }
    public string? StreetRight { get; set; }
    public string? StreetBehind { get; set; }
    public int PostalCode { get; set; }
    public string? Colony { get; set; }
    public string? Municipality { get; set; }
    public string? State { get; set; }
    public int PhoneNumber { get; set; }
    public string? Sustaining  { get; set; }
    public string? WebPage { get; set; }
    public string? SurveyerEmail { get; set; }
}
#endregion

#region Staff information
[Owned]
public class StaffInformation
{
    public Dictionary<string, StaffDetailCount> EmployeesByRoles { get; set; } = null!;
    public Dictionary<EducationLevel, StaffDetailCount> TeachersEducation { get; set; } = null!;
    public List<TeachersByShift> TeachersDetailsByShift { get; set; } = null!;
    public List<TeachersYearsRange> TeachersAgeRange { get; set; } = null!;  //5
    public List<TeachersYearsRange> TeachersAntiquityRange { get; set; } = null!;  //6
}

[Owned]
public class StaffDetailCount
{
    public Gender Gender { get; set; }
    public int TotalEmployees { get; set; }
    public int Disability { get; set; }
    public int IndigenousSpeaker { get; set; }
}

[Owned]
public class TeachersByShift
{
    public WorkdayShift Shift { get; set; }
    public int Male { get; set; }
    public int Female { get; set; }
    public int WithDisability { get; set; }
    public int SpeaksIndigenousLanguage { get; set; }
    public Dictionary<EducationLevel, int> EducationLevel { get; set; } = null!;
    public bool IsSchoolModality { get; set; } = false;
}
#endregion

#region Teaching Levels Gender
[Owned]
public class TeachingLevelsGender
{
    public EducationLevel TeacherLevel { get; set; }
    public EducationLevel TeachingLevel { get; set; }
    public int Male { get; set; }
    public int Female { get; set; }
}

[Owned]
public class TeachersYearsRange
{
    public string AgeRange { get; set; } = null!;
    public string Male { get; set; } = null!;
    public string Female { get; set; } = null!;
}

[Owned]
public class TeachersStudying
{
    public int NationalTotal { get; set; }
    public int NationalWithScolarship { get; set; }
    public int InternationalTotal { get; set; }
    public int InternationalWithoutScolarship { get; set; }
    public Dictionary<string, int> ScolarshipGenders { get; set; } = null!;
    public int ScolarshipTotal { get; set; }
    public int ScolarshipWithDisability { get; set; }
    public int ScolarshipIndigenousSpeaker { get; set; }
}
#endregion

#region Exchange Programs
[Owned]
public class ExchangePrograms
{
    public Dictionary<string , int> Programs { get; set; } = null!;
}
#endregion

#region School Modality
[Owned]
public class StudentsByCarrers
{
    public EducationLevel TeachingLevel { get; set; }
    public string CarrerName { get; set; } = null!;
    public int TotalStudents { get; set; }
}

[Owned]
public class StudentsScolarship
{
    public string ScolarshipSource { get; set; } = null!;
    public int Male { get; set; }
    public int Female { get; set; }
    public int WithDisability { get; set; }
    public int IndigenousSpeaker { get; set; }
}
#endregion

#region School Modality
[Owned]
public class TeachersModality
{
    public List<TeachersByShift> TeachersDetailsByShift { get; set; } = null!;
}
#endregion