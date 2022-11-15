using Marrodent.ServicesDashboard.Models.Enum;

namespace Marrodent.ServicesDashboard.Interfaces;

public interface IServiceController
{
     Task<ServiceState> GetState(string websiteName);
}