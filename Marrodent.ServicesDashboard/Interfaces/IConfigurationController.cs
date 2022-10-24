using Marrodent.ServicesDashboard.Models.Models;

namespace Marrodent.ServicesDashboard.Interfaces;

public interface IConfigurationController
{
    ICollection<IISApp>? GetIisApps();
    ICollection<WindowsServiceApp>? GetwWindowsServiceApps();
    ICollection<WindowsTaskSchedulerApp>? GetWindowsTaskSchedulerApps();
}