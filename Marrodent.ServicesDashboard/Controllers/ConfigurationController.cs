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
        public ICollection<IISApp>? GetIisApps => JsonConvert.DeserializeObject<List<IISApp>>(File.ReadAllText($@"{_basePath}\.json"));
        public ICollection<WindowsServiceApp>? GetwWindowsServiceApps => JsonConvert.DeserializeObject<List<WindowsServiceApp>>(File.ReadAllText($@"{_basePath}\.json"));
        public ICollection<WindowsTaskSchedulerApp>? GetWindowsTaskSchedulerApps => JsonConvert.DeserializeObject<List<WindowsTaskSchedulerApp>>(File.ReadAllText($@"{_basePath}\.json"));
        public ICollection<OtherApp>? GetOtherApps => JsonConvert.DeserializeObject<List<OtherApp>>(File.ReadAllText($@"{_basePath}\.json"));
    }
}
