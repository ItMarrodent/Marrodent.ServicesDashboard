using Marrodent.ServicesDashboard.Models.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace Marrodent.ServicesDashboard.Interfaces;

public interface ILogController
{
    ICollection<string> GetLogs(ServiceApp serviceApp);
    bool HasErrorsToday(ServiceApp serviceApp);
}