using System.Diagnostics;
using Marrodent.ServicesDashboard.Interfaces;
using Marrodent.ServicesDashboard.Models.Enum;

namespace Marrodent.ServicesDashboard.Controllers
{
    public sealed class WindowsServicesController : IServiceController
    {
        //Private
        private List<string> _processes;

        //CTOR
        public WindowsServicesController()
        {
            Refresh();
        }
        
        //Public
        public void Refresh()
        {
            _processes = new List<string>();
            _processes.AddRange(Process.GetProcesses("10.48.86.234").Select(x => x.ProcessName));
            _processes.AddRange(Process.GetProcesses("10.48.86.235").Select(x => x.ProcessName));
            _processes = _processes.Distinct().OrderBy(x => x).ToList();
        }

        public ServiceState GetState(string service) => _processes.Contains(service) ? ServiceState.Running : ServiceState.Stopped;
    }
}