//Usings
using Marrodent.ServicesDashboard.Models.Models;
using Newtonsoft.Json;

//IIS
ICollection<IISApp> iisApps = new List<IISApp>();
File.WriteAllText(@"json\iis.json", JsonConvert.SerializeObject(iisApps));

//Services
ICollection<WindowsServiceApp> windowsServiceApps = new List<WindowsServiceApp>();
File.WriteAllText(@"json\services.json", JsonConvert.SerializeObject(windowsServiceApps));

//Scheduler
ICollection<WindowsTaskSchedulerApp> windowsTaskSchedulerApps = new List<WindowsTaskSchedulerApp>();
File.WriteAllText(@"json\tasks.json", JsonConvert.SerializeObject(windowsTaskSchedulerApps));