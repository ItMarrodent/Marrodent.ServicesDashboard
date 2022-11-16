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

    [JsonIgnore] public string Errors { get; set; } = "No error log folder";

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
}