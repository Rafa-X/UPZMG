using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using UPZMG.Shared.Enums;

namespace UPZMG.Persistence.Models;

/// <summary>
/// Resources module.
/// Represents the annual inventory of technological resources in the university.
/// </summary>

public class AnnualTICInventory
{
    public Guid Id { get; set; }
    public Identificacion Identification { get; set; } = null!;
    public int PeriodId { get; set; } //fk
    public ComputersDetails ComputersDetails { get; set; } = null!; //1-10
    public PrintersDetails PrintersDetails { get; set; } = null!; //11-12
    public WiFiDetails WiFiDetails { get; set; } = null!; //13-14
    public ServersDetails ServersDetails { get; set; } = null!; //15-17
    public ComputingToolsDetails ComputingToolsDetails { get; set; } = null!; //18-19
}



/*----------  HELPERS   ----------*/
[Owned]
public class ComputersDetails
{
    public List<ComputersStatusDetails> ComputersStatusDetails { get; set; } = null!; //1,2
    public Dictionary<ResourceUsedBy, int> InOperationUsedBy { get; set; } = null!; //3
    public PCInOperationEducation PCInOperationEducation { get; set; } = null!; //6,8
    public Dictionary<ResourceUsedBy, int> HasInternet { get; set; } = null!; //4
    public Dictionary<string, int> Type { get; set; } = null!; //5

}

[Owned]
public class ComputersStatusDetails
{
    public string Status { get; set; } = null!;
    public int Count { get; set; }
    public List<string> StoragedReason { get; set; } = null!; //only for storaged or reserve status
}

[Owned]
public class PCInOperationEducation
{
    public Dictionary<string, int> RAM { get; set; } = null!;
    public Dictionary<string, int> OperativeSystem { get; set; } = null!;
    public Dictionary<string, int> Storage { get; set; } = null!;
    public Dictionary<string, int> ResourceAntiquity { get; set; } = null!;
    public Dictionary<string, int> AdquisitionType { get; set; } = null!;
    public PCsNetworkDetails NetworkDetails { get; set; } = null!; //8-10
}

[Owned]
public class PCsNetworkDetails
{
    public Dictionary<string, int> NetworkType { get; set; } = null!; //8
    public List<string> ConnectionType { get; set; } = null!; //9
    public Dictionary<string, int> NetworkSpeed { get; set; } = null!; //10
}


[Owned]
public class PrintersDetails
{
    public bool PrinterForStudents { get; set; } //11
    public bool PrintsFreeStudents { get; set; } //12
}

[Owned]
public class WiFiDetails
{
    public bool WiFiPublicSpaces { get; set; } //13
    public List<string> WhoHasAccess { get; set; } = null!; //14
}

[Owned]
public class ServersDetails
{
    public bool HasServers { get; set; }
    public int ServersCount { get; set; }
    public int ComputersForServers { get; set; }
}

[Owned]
public class ComputingToolsDetails
{
    public Dictionary<string, char>  Processes { get; set; } = null!; //18
    public Dictionary<string, string> AdquisitionType { get; set; } = null!; //19
}