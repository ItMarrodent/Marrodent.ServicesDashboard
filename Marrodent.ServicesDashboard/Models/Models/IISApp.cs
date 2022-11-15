using Marrodent.ServicesDashboard.Interfaces;
using Marrodent.ServicesDashboard.Models.Abstracts;
using Marrodent.ServicesDashboard.Models.Enum;

namespace Marrodent.ServicesDashboard.Models.Models
{
    public sealed class IISApp : ServiceApp
    {
        private readonly IWebServiceController _iisControler;

        //CTOR
        public IISApp() : base(ServiceType.IIS)
        {
        }
    }
}
