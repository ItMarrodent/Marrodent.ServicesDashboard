using Marrodent.ServicesDashboard.Models.Abstracts;
using Marrodent.ServicesDashboard.Models.Enum;

namespace Marrodent.ServicesDashboard.Models.Models
{
    public sealed class IISApp : ServiceApp
    {
        //CTOR
        public IISApp() : base(ServiceType.IIS)
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
