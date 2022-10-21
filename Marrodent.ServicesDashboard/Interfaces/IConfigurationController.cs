using Marrodent.ServicesDashboard.Models.Models;

namespace Marrodent.ServicesDashboard.Interfaces;

public interface IConfigurationController
{
    ICollection<IISApp>? GetIisApps { get; }
    ICollection<WindowsServiceApp>? GetwWindowsServiceApps { get; }
    ICollection<WindowsTaskSchedulerApp>? GetWindowsTaskSchedulerApps { get; }
    ICollection<OtherApp>? GetOtherApps { get; }
}