using Marrodent.ServicesDashboard.Models.Enum;

namespace Marrodent.ServicesDashboard.Interfaces;

public interface IWebServiceController
{
     Task Refresh();
     Task<ServiceState> GetState(string websiteName);
     Task Start(string address, string websiteName);
     Task Stop(string address, string websiteName);
}