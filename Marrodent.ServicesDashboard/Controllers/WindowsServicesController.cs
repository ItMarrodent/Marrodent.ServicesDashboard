using System.Diagnostics;
using Marrodent.ServicesDashboard.Interfaces;
using Marrodent.ServicesDashboard.Models.Enum;
using Marrodent.ServicesDashboard.Models.Models;
using Microsoft.Extensions.Options;

namespace Marrodent.ServicesDashboard.Controllers
{
    public sealed class WindowsServicesController : IServiceController
    {
        //Private
        private readonly TerminalConfig _config;
        private Dictionary<string, ICollection<string>> _processes;

        //CTOR
        public WindowsServicesController(IOptions<TerminalConfig> options)
        {
            _config = options.Value;
            Refresh();
        }
        
        //Public
        public void Refresh()
        {
            foreach (var terminal in _config.Terminals)
            {
                _processes.Add(terminal, Process.GetProcesses("10.48.86.235").Select(x => x.ProcessName).ToList());
            }
        }

        public ServiceState GetState(string service, string address) => _processes[address].Contains(service) ? ServiceState.Running : ServiceState.Stopped;
    }
}