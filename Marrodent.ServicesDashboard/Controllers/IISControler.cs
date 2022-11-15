using Marrodent.ServicesDashboard.Interfaces;
using Marrodent.ServicesDashboard.Models.Enum;

namespace Marrodent.ServicesDashboard.Controllers;

public sealed class IISControler : iIISControler
{
    public ServiceState GetState(string websiteName)
    {
        return ServiceState.Disabled;
    }
}