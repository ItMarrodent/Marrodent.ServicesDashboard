using Marrodent.ServicesDashboard.Models.Abstracts;
using Marrodent.ServicesDashboard.Models.Models;

namespace Marrodent.ServicesDashboard.Interfaces;

public interface IConfigurationController
{
    ICollection<ServiceApp> GetAll();
    ICollection<IISApp>? GetIisApps();
    ICollection<WindowsServiceApp>? GetWindowsServiceApps();
    ICollection<WindowsTaskSchedulerApp>? GetWindowsTaskSchedulerApps();
}