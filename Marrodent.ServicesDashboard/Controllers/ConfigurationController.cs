using Marrodent.ServicesDashboard.Models.Models;
using System.Reflection;
using Newtonsoft.Json;
using Marrodent.ServicesDashboard.Interfaces;

namespace Marrodent.ServicesDashboard.Controllers
{
    public sealed class ConfigurationController : IConfigurationController
    {
        //Private
        private readonly string _basePath;

        //CTOR
        public ConfigurationController()
        {
            _basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty;
        }

        //Public
        public ICollection<IISApp>? GetIisApps()
        {
            return !File.Exists($@"{_basePath}\iis.json") 
                ? null
                : JsonConvert.DeserializeObject<List<IISApp>>(File.ReadAllText($@"{_basePath}\iis.json"));
        }

        public ICollection<WindowsServiceApp>? GetwWindowsServiceApps()
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
    }
}
