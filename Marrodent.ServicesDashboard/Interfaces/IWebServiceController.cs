using Marrodent.ServicesDashboard.Models.Enum;

namespace Marrodent.ServicesDashboard.Interfaces;

public interface IWebServiceController
{
     Task Refresh();
     Task<ServiceState> GetState(string websiteName);
     Task Stop(string websiteName);
}