using Marrodent.ServicesDashboard.Models.Enum;

namespace Marrodent.ServicesDashboard.Interfaces;

public interface iIISControler
{
    ServiceState GetState(string websiteName);
}