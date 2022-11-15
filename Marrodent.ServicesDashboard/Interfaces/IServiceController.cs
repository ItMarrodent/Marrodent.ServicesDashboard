using Marrodent.ServicesDashboard.Models.Enum;

namespace Marrodent.ServicesDashboard.Interfaces;

public interface IServiceController
{
    void Refresh();
    void Stop(string websiteName, string address);
    ServiceState GetState(string websiteName, string address);
}