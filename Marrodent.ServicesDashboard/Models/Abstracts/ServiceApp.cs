using Marrodent.ServicesDashboard.Models.Enum;
using Marrodent.ServicesDashboard.Models.Interfaces;

namespace Marrodent.ServicesDashboard.Models.Abstracts;

public abstract class ServiceApp : IIdentity
{
    //Public - int
    public int Id { get; set; }
    
    //Public - string
    public string? Name { get; set; }
    public string? TerminalAddress { get; set; }
    public string? CorrectLogAddress { get; set; }
    public string? ErrorLogAddress { get; set; }
    public string? Description { get; set; }

    //Public - enum
    public readonly ServiceType Type;
    public ServiceState State { get; set; }
    
    //CTOR
    protected ServiceApp(ServiceType type)
    {
        Type = type;
    }

    //Public - functions
    public virtual ServiceState GetState => ServiceState.Unknown;
    public virtual ICollection<string> GetCorrectLogs(DateTime date) => GetLogsBase(date, CorrectLogAddress);
    public virtual ICollection<string> GetErrorLogs(DateTime date) => GetLogsBase(date, ErrorLogAddress);
    
    //Private - functions
    private ICollection<string> GetLogsBase(DateTime date, string path)
    {
        return Directory.GetFiles(path)
            .Select(x => new FileInfo(x))
            .Where(x => x.CreationTime >= date)
            .SelectMany(x => File.ReadAllLines(x.FullName))
            .ToList();
    }
}