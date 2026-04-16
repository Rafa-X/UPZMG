using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models;

/// <summary>
/// Resources module.
/// Represents the infrastructure details of a physical space in the university.
/// </summary>

public class Infraestructure
{
    //Part I - Property characteristics
    //General information
    public Guid Id { get; set; }
    public Identificacion Identification { get; set; } = null!;

    //Property details 1-6
    public PropertyDetails PropertyDetails { get; set; } = null!;

    //Types and details of buildings 7-17
    public SchoolFacilities SchoolFacilities { get; set; } = null!;
    
    //Basic services details 18-24
    public List<BasicServices> BasicServices { get; set; } = null!; //Internet, water, electricity, gas

    //Bathrooms details 25-29
    public BathroomsDetails Bathrooms { get; set; } = null!;

    //Maintenance and risk prevention details 30-39
    public (int InUse, int OutOfService) WaterFountains { get; set; }
    public MaintenanceDetails Maintenance { get; set; } = null!;
    public bool CivilProtection { get; set; }
    public List<RiskPreventionDetails> RiskPrevention { get; set; } = null!;
    public List<string> SecurityConstructions { get; set; } = null!;
    
    //Other infrastructure details 40-41
    public bool HasResidenceHall { get; set; }
    public ParkingLots ParkingLots { get; set; } = null!;

    //Part II - Infrastructure for people with disabilities
    //Disabilities adaptations 1-9
    public DisabilitiesAdaptations DisabilitiesAdaptations { get; set; } = null!;
}

#region Identification
[Owned]
public class Identificacion
{
    public int SchoolId { get; set; }
    [MaxLength(50)]
    public string? SchoolName { get; set; }
    public string? SurveyedBy { get; set; }
    public byte[] Signature { get; set; } = null!; //save as image
    public DateOnly SurveyDate { get; set; }
}
#endregion

#region Property details
[Owned]
public class PropertyDetails
{
    public int Workstations { get; set; }
    public EducationServices EducationServices { get; set; } = null!;
    public Dictionary<string, string> BuiltReason { get; set; } = null!;
    public bool TemporarySuperiorEducationUse { get; set; }
    public string? MissingInfrastructureReason { get; set; }
}

[Owned]
public class EducationServices
{
    public List<EducationServicesList> Service { get; set; } = null!;
    public bool BuiltForEducationalUse { get; set; }
}
#endregion

#region School facilities
[Owned]
public class SchoolFacilities
{
    public PropertyAntiquity SchoolPropertyAntiquity { get; set; } = null!;
    public SchoolFacilitiesTypes Types { get; set; } = null!; //Types of facilities and educational spaces
    public SquareMeters SquareMeters { get; set; } = null!; //square meters range of the property
    public int FacilitiesUsedForEducation { get; set; }
    public int TotalFacilitiesCount { get; set; }
    public List<SchoolFacilityDetails> FacilitiesDetails { get; set; } = null!; //Building details - once per building - 13-17
    public List<Guid> Facilities { get; set; } = null!; //List of SchoolFacilities
}

[Owned]
public class EducationalSpace
{
    public EducationalSpaceType SpaceType { get; set; }
    public int Count { get; set; }
    public bool InUse { get; set; }
}

[Owned]
public class SchoolFacilitiesTypes
{
    public List<SchoolFacilityType> Types { get; set; } = null!; //List of spaces types
    public List<EducationalSpace> EducationalSpaces { get; set; } = null!; //List of educational spaces types and counts
}

[Owned]
public class SchoolFacilityDetails
{
    public Guid FacilityId { get; set; } //fk to SchoolFacility
    public int CantFloors { get; set; }
    public SchoolFacilityType Type { get; set; } //Type of space - classroom, auditorium, office, etc.
    public Dictionary<string, string> Materials { get; set; } = null!; //Walls, roof, floor materials
}


[Owned]
public class BasicServices
{
    public BasicServicesTypes ServiceName { get; set; }
    public bool IsRegular { get; set; }
    public Dictionary<string, bool> Details { get; set; } = null!;
}
#endregion

#region Bathrooms
[Owned]
public class BathroomsDetails
{
    public (string Gender, int Count) BathroomRooms { get; set; }
    public List<ToiletsByGender> ToiletsByGender { get; set; } = null!;
    public List<BathroomsUnitsDetails> Toilets { get; set; } = null!;
    public List<BathroomsUnitsDetails> Sinks { get; set; } = null!;
    public List<BathroomsUnitsAssignation> ToiletsAssignation { get; set; } = null!;
    public List<BathroomsUnitsDetails> SinksAssignation { get; set; } = null!;
}

[Owned]
public class BathroomsUnitsDetails
{
    public string UnitName { get; set; } = null!;
    public int InUse { get; set; }
    public int OutOfService { get; set; }
    public int Count { get; set; }
}

[Owned]
public class BathroomsUnitsAssignation
{
    public string UnitName { get; set; } = null!;
    public int Students { get; set; }
    public int Employees { get; set; }
    public int General { get; set; }
}

[Owned]
public class ToiletsByGender
{
    public string Type { get; set; } = null!;
    public int StudentsCount { get; set; }
    public int EmployeesCount { get; set; }
}
#endregion

#region Maintenance and risk prevention
[Owned]
public class MaintenanceDetails
{
    public bool HasMaintenanceArea { get; set; }
    public List<string> MaintenancePerformed5Years { get; set; } = null!;
    public List<string> NewConstructions { get; set; } = null!;
    public string BathroomsCleanFrequency { get; set; } = null!;
}

[Owned]
public class RiskPreventionDetails
{
    public string Measure { get; set; } = null!;
    public int Existing { get; set; }
    public int InUse { get; set; }
}
#endregion

#region Disabilities
[Owned]
public class DisabilitiesAdaptations
{
    public bool IsDisabilitiesAdapted { get; set; }
    public Dictionary<string, bool> AreasAdapted { get; set; } = null!;
    public List<BathroomsDisabilities> BathroomsAdapted { get; set; } = null!;
    public int DisabilitiesSignsCount { get; set; }
    public Dictionary<string, int> DisabilitiesSigns { get; set; } = null!;
    public List<string> Adaptations { get; set; } = null!;
    public bool ExistAdaptedClassrooms { get; set; }
    public int SoftwareForDisabilities { get; set; }
    public EquipmentForDisabilities EquipmentForDisabilities { get; set; } = null!;
}

[Owned]
public class BathroomsDisabilities
{
    public string Gender { get; set; } = null!;
    public int InUse { get; set; }
    public int OutOfService { get; set; }
}

[Owned]
public class EquipmentForDisabilities
{
    public string Equipment { get; set; } = null!;
    public int InOperation { get; set; }
    public int InReparation { get; set; }
    public int InStorage { get; set; }
}
#endregion