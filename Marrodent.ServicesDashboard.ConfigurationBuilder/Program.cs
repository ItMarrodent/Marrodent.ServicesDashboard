//Usings
using Marrodent.ServicesDashboard.Models.Models;
using Newtonsoft.Json;

//IIS
ICollection<IISApp> iisApps = new List<IISApp>();

iisApps.Add(new IISApp
{
    Name = "Platforma WebService",
    TerminalAddress = "10.48.86.234:84",
    Id = 1,
    Description = "PL and CZ - Main plaforma and enova connection service"
});

iisApps.Add(new IISApp
{
    Name = "Enova integrator WebService",
    TerminalAddress = "10.48.86.234:89",
    Id = 2,
    Description = "CZ - data export from enova to helios"
});

iisApps.Add(new IISApp
{
    Name = "Printing API",
    TerminalAddress = "10.48.86.234:90",
    Id = 3,
    Description = "CZ - Invoice printing on demand"
});

iisApps.Add(new IISApp
{
    Name = "RODO WebService",
    TerminalAddress = "10.48.86.234:83",
    Id = 4,
    Description = "PL - rodo customer service"
});

iisApps.Add(new IISApp
{
    Name = "Global attachments",
    TerminalAddress = "10.48.86.234:92",
    Id = 5,
    Description = "PL and CZ attachment service"
});

iisApps.Add(new IISApp
{
    Name = "KHT PL WebService",
    TerminalAddress = "10.48.86.234:82",
    Id = 6,
    Description = "PL - old attachment service"
});

iisApps.Add(new IISApp
{
    Name = "KHT CZ WebService",
    TerminalAddress = "10.48.86.234:85",
    Id = 7,
    Description = "CZ - old attachment service"
});

File.WriteAllText(@"json\iis.json", JsonConvert.SerializeObject(iisApps));

//Services
ICollection<WindowsServiceApp> windowsServiceApps = new List<WindowsServiceApp>();
File.WriteAllText(@"json\services.json", JsonConvert.SerializeObject(windowsServiceApps));

//Scheduler
ICollection<WindowsTaskSchedulerApp> windowsTaskSchedulerApps = new List<WindowsTaskSchedulerApp>();
File.WriteAllText(@"json\tasks.json", JsonConvert.SerializeObject(windowsTaskSchedulerApps));