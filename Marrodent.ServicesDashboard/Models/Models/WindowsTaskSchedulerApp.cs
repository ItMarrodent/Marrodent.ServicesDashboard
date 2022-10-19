using Marrodent.ServicesDashboard.Models.Abstracts;
using Marrodent.ServicesDashboard.Models.Enum;

namespace Marrodent.ServicesDashboard.Models.Models
{
    public sealed class WindowsTaskSchedulerApp : ServiceApp
    {
        //CTOR
        public WindowsTaskSchedulerApp() : base(ServiceType.WindowsTaskScheduler)
        {
        }
    }
}
