using Marrodent.ServicesDashboard.Models.Enum;

namespace Marrodent.ServicesDashboard.Interfaces;

public interface IServiceController
{
    void Refresh();
    ServiceState GetState(string websiteName, string address);
}