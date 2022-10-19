using Marrodent.ServicesDashboard.Models.Abstracts;
using Marrodent.ServicesDashboard.Models.Enum;

namespace Marrodent.ServicesDashboard.Models.Models
{
    public sealed class OtherApp : ServiceApp
    {
        //CTOR
        public OtherApp() : base(ServiceType.Other)
        {
        }
    }
}
