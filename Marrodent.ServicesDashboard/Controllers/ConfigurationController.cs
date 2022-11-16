using Marrodent.ServicesDashboard.Models.Models;
using System.Reflection;
using Newtonsoft.Json;
using Marrodent.ServicesDashboard.Interfaces;
using Marrodent.ServicesDashboard.Models.Abstracts;
using Microsoft.Extensions.Options;

namespace Marrodent.ServicesDashboard.Controllers
{
    public sealed class ConfigurationController : IConfigurationController
    {
        //Private
        private readonly string _basePath;
        private readonly TerminalConfig _terminalConfig;

        //CTOR
        public ConfigurationController(IOptions<TerminalConfig> options)
        {
            _basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty;
            _terminalConfig = options.Value;
        }

        //Public
        public ICollection<ServiceApp> GetAll()
        {
            List<ServiceApp> result = new List<ServiceApp>();
            
            result.AddRange(GetIisApps()!);
            result.AddRange(GetWindowsServiceApps()!);
            result.AddRange(GetWindowsTaskSchedulerApps()!);

            return result;
        }

        public ICollection<IISApp>? GetIisApps()
        {
            return !File.Exists($@"{_basePath}\iis.json") 
                ? null
                : JsonConvert.DeserializeObject<List<IISApp>>(File.ReadAllText($@"{_basePath}\iis.json"));
        }

        public ICollection<WindowsServiceApp>? GetWindowsServiceApps()
        {
            return !File.Exists($@"{_basePath}\services.json")
                ? null
                : JsonConvert.DeserializeObject<List<WindowsServiceApp>>(File.ReadAllText($@"{_basePath}\services.json"));
        }

        public ICollection<WindowsTaskSchedulerApp>? GetWindowsTaskSchedulerApps()
        {
            return !File.Exists($@"{_basePath}\tasks.json") 
                ? null
                : JsonConvert.DeserializeObject<List<WindowsTaskSchedulerApp>>(File.ReadAllText($@"{_basePath}\tasks.json"));
        }

        public ICollection<Terminal> GetTerminals()
        {
            return _terminalConfig.Terminals.Select((value, index) => new { value, index })
                .Select(terminal => new Terminal
                {
                    Address = terminal.value,
                    TotalRam = _terminalConfig.Ram[terminal.index]
                }).ToList();
        }
    }
}
