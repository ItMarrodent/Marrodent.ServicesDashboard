using Marrodent.ServicesDashboard.Interfaces;
using Marrodent.ServicesDashboard.Models.Abstracts;
using Marrodent.ServicesDashboard.Models.Enum;

namespace Marrodent.ServicesDashboard.Models.Models
{
    public sealed class IISApp : ServiceApp
    {
        private readonly iIISControler _iisControler;

        //CTOR
        public IISApp(iIISControler iisControler) : base(ServiceType.IIS)
        {
            _iisControler = iisControler;
        }
        
        //Public
        public override ServiceState GetState => _iisControler.GetState(ServiceName);
    }
}
