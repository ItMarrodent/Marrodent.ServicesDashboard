using Marrodent.ServicesDashboard.Models.Abstracts;
using Marrodent.ServicesDashboard.Models.Enum;
using Microsoft.Web.Administration;

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
                using var manager = ServerManager.OpenRemote(@"");
                var site = manager.Sites.FirstOrDefault(x => x.Name == ServiceName);

                if (site != null)
                {
                    return site.State switch
                    {
                        ObjectState.Starting => ServiceState.Running,
                        ObjectState.Started => ServiceState.Running,
                        ObjectState.Stopping => ServiceState.Stopped,
                        ObjectState.Stopped => ServiceState.Stopped,
                        ObjectState.Unknown => ServiceState.Unknown,
                        _ => throw new ArgumentOutOfRangeException()
                    };
                }

                return ServiceState.Unknown;
            }
        }
    }
}
