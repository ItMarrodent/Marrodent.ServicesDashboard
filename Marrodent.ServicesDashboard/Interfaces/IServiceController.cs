using Marrodent.ServicesDashboard.Models.Enum;

namespace Marrodent.ServicesDashboard.Interfaces;

public interface IServiceController
{
    void Refresh();
    void Start(string service, string address);
    void Stop(string service, string address);
    ServiceState GetState(string websiteName, string address);
}