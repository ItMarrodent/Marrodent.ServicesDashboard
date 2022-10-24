//Usings

using Marrodent.ServicesDashboard.Models.Enum;
using Marrodent.ServicesDashboard.Models.Models;
using Newtonsoft.Json;

//IIS
ICollection<IISApp> iisApps = new List<IISApp>();

iisApps.Add(new IISApp
{
    Name = "Platforma WebService",
    TerminalAddress = "10.48.86.234:84",
    Id = 1,
    Description = "PL and CZ - Main plaforma and enova connection service",
    State = ServiceState.Unknown
});

iisApps.Add(new IISApp
{
    Name = "Enova integrator WebService",
    TerminalAddress = "10.48.86.234:89",
    Id = 2,
    Description = "CZ - data export from enova to helios",
    State = ServiceState.Unknown
});

iisApps.Add(new IISApp
{
    Name = "Printing API",
    TerminalAddress = "10.48.86.234:90",
    Id = 3,
    Description = "CZ - Invoice printing on demand",
    State = ServiceState.Unknown
});

iisApps.Add(new IISApp
{
    Name = "RODO WebService",
    TerminalAddress = "10.48.86.234:83",
    Id = 4,
    Description = "PL - rodo customer service",
    State = ServiceState.Unknown
});

iisApps.Add(new IISApp
{
    Name = "Global attachments",
    TerminalAddress = "10.48.86.234:92",
    Id = 5,
    Description = "PL and CZ attachment service",
    State = ServiceState.Unknown
});

iisApps.Add(new IISApp
{
    Name = "KHT PL WebService",
    TerminalAddress = "10.48.86.234:82",
    Id = 6,
    Description = "PL - old attachment service",
    State = ServiceState.Unknown
});

iisApps.Add(new IISApp
{
    Name = "KHT CZ WebService",
    TerminalAddress = "10.48.86.234:85",
    Id = 7,
    Description = "CZ - old attachment service",
    State = ServiceState.Unknown
});

File.WriteAllText(@"json\iis.json", JsonConvert.SerializeObject(iisApps));

//Services
ICollection<WindowsServiceApp> windowsServiceApps = new List<WindowsServiceApp>();

windowsServiceApps.Add(new WindowsServiceApp
{
    Name = "AutomatE3",
    TerminalAddress = "10.48.86.235",
    Id = 1,
    Description = "PL - export E3 data",
    State = ServiceState.Unknown
});

windowsServiceApps.Add(new WindowsServiceApp
{
    Name = "BST.EmailService",
    TerminalAddress = "10.48.86.235",
    Id = 2,
    Description = "CZ - customer email sending service",
    State = ServiceState.Unknown
});

windowsServiceApps.Add(new WindowsServiceApp
{
    Name = "BST.FillrateService",
    TerminalAddress = "10.48.86.235",
    Id = 3,
    Description = "CZ - fillrate service report export",
    State = ServiceState.Unknown
});

windowsServiceApps.Add(new WindowsServiceApp
{
    Name = "BST.PrintService",
    TerminalAddress = "10.48.86.235",
    Id = 4,
    Description = "CZ - printing documents on warehouse service",
    State = ServiceState.Unknown
});

windowsServiceApps.Add(new WindowsServiceApp
{
    Name = "EnovaServer",
    TerminalAddress = "10.48.86.235",
    Id = 5,
    Description = "PL and CZ - enova task scheduler service",
    State = ServiceState.Unknown
});

windowsServiceApps.Add(new WindowsServiceApp
{
    Name = "ImportE3",
    TerminalAddress = "10.48.86.235",
    Id = 6,
    Description = "PL - import E3 data",
    State = ServiceState.Unknown
});

windowsServiceApps.Add(new WindowsServiceApp
{
    Name = "BST.IISGuard",
    TerminalAddress = "10.48.86.234",
    Id = 7,
    Description = "PL and CZ - checking iis services",
    State = ServiceState.Unknown
});

windowsServiceApps.Add(new WindowsServiceApp
{
    Name = "EnovaServer integrator",
    TerminalAddress = "10.48.86.234",
    Id = 8,
    Description = "CZ - data export from enova to helios",
    State = ServiceState.Unknown
});

File.WriteAllText(@"json\services.json", JsonConvert.SerializeObject(windowsServiceApps));

//Scheduler
ICollection<WindowsTaskSchedulerApp> windowsTaskSchedulerApps = new List<WindowsTaskSchedulerApp>();
File.WriteAllText(@"json\tasks.json", JsonConvert.SerializeObject(windowsTaskSchedulerApps));