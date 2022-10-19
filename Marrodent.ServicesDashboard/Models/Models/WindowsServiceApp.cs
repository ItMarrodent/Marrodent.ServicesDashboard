using Marrodent.ServicesDashboard.Models.Abstracts;
using Marrodent.ServicesDashboard.Models.Enum;

namespace Marrodent.ServicesDashboard.Models.Models
{
    public sealed class WindowsServiceApp : ServiceApp
    {
        //CTOR
        public WindowsServiceApp() : base(ServiceType.WindowsService)
        {
        }
    }
}
