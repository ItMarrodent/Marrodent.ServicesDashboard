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
        
        //Public
        public override ServiceState GetState
        {
            get
            {
                return ServiceState.Unknown;
            }
        }
    }
}
