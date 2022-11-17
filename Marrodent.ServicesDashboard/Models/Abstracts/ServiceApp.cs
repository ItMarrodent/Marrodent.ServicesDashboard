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
            if (Errors == "Yes")
            {
                return "#dbbe02";
            }
            
            switch (State)
            {
                case ServiceState.Running:
                    return "#449e48";
                case ServiceState.Stopped:
                    return "#990000";
                case ServiceState.Disabled:
                case ServiceState.Unknown:
                default:
                    return "#7d7d7d";
            }
        }
    }

    //Public - enum
    public readonly ServiceType Type;
    [JsonIgnore] public ServiceState State { get; set; }

    //CTOR
    protected ServiceApp(ServiceType type)
    {
        Type = type;
    }
}