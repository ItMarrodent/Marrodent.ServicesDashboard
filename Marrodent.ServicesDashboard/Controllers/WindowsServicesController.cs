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
            _processes = new Dictionary<string, ICollection<string>>();
            
            foreach (var terminal in _config.Terminals)
            {
                _processes.Add(terminal, Process.GetProcesses(terminal).Select(x => x.ProcessName).ToList());
            }
        }

        public void Start(string service, string address)
        {
            Process.Start("CMD.exe", $"/C sc \\\\{address} start \"{service}\"");
        }

        public void Stop(string service, string address)
        {
            Process.Start("CMD.exe", $"/C sc \\\\{address} stop \"{service}\"");
        }

        public ServiceState GetState(string service, string address) => _processes[address].Contains(service) ? ServiceState.Running : ServiceState.Stopped;
    }
}