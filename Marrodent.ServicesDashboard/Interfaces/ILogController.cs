using Marrodent.ServicesDashboard.Models.Abstracts;

namespace Marrodent.ServicesDashboard.Interfaces;

public interface ILogController
{
    void GetLogs(ServiceApp serviceApp);
}