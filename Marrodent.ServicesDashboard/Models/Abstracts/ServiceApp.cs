using Marrodent.ServicesDashboard.Models.Enum;
using Marrodent.ServicesDashboard.Models.Interfaces;
using Newtonsoft.Json;

namespace Marrodent.ServicesDashboard.Models.Abstracts;

public abstract class ServiceApp : IIdentity
{
    //Public - int
    public int Id { get; set; }

    //Public - string
    public string? ServiceName { get; set; }
    public string? WindowsServiceName { get; set; }
    public string? DisplayName { get; set; }
    public string? Address { get; set; }
    public string? CorrectLogAddress { get; set; }
    public string? ErrorLogAddress { get; set; }
    public string? Description { get; set; }

    [JsonIgnore]
    public string CardColor
    {
        get
        {
            switch (State)
            {
                case ServiceState.Running:
                    return "#449e48";
                case ServiceState.Stopped: 
                    return "#990000";
                case ServiceState.Disabled:
                case ServiceState.Unknown:
                    return "#413839";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    //Public - enum
    public readonly ServiceType Type;
    public ServiceState State { get; set; }

    //CTOR
    protected ServiceApp(ServiceType type)
    {
        Type = type;
    }

    //Public - functions
    public virtual ICollection<string> GetCorrectLogs(DateTime date) => GetLogsBase(date, CorrectLogAddress);
    public virtual ICollection<string> GetErrorLogs(DateTime date) => GetLogsBase(date, ErrorLogAddress);

    public virtual void Start()
    {
        
    }

    public virtual void Stop()
    {
        
    }

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