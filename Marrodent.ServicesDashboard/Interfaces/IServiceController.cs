using Marrodent.ServicesDashboard.Models.Enum;

namespace Marrodent.ServicesDashboard.Interfaces;

public interface IServiceController
{
     Task Refresh();
     Task<ServiceState> GetState(string websiteName);
}