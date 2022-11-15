using Marrodent.ServicesDashboard.Controllers;
using Marrodent.ServicesDashboard.Interfaces;
using Marrodent.ServicesDashboard.Models.Abstracts;
using Marrodent.ServicesDashboard.Models.Enum;

namespace Marrodent.ServicesDashboard.Models.Models
{
    public sealed class IISApp : ServiceApp
    {
        private readonly IServiceController _iisControler;

        //CTOR
        public IISApp() : base(ServiceType.IIS)
        {
        }
        
        //Public
        public override ServiceState GetState => _iisControler?.GetState(ServiceName) ?? ServiceState.Unknown;
    }
}
