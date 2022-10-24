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
    State = ServiceState.Unknown,
    CorrectLogAddress = @"C:\Users\bst.produkcja\Desktop\E3\E3 Logi\Poprawne",
    ErrorLogAddress = @"C:\Users\bst.produkcja\Desktop\E3\E3 Logi\Błędne"
});

windowsServiceApps.Add(new WindowsServiceApp
{
    Name = "BST.EmailService",
    TerminalAddress = "10.48.86.235",
    Id = 2,
    Description = "CZ - customer email sending service",
    State = ServiceState.Unknown,
    CorrectLogAddress = @"C:\Users\bst.produkcja\Desktop\BST\EmailService\Logs\Correct",
    ErrorLogAddress = @"C:\Users\bst.produkcja\Desktop\BST\EmailService\Logs\Error"
});

windowsServiceApps.Add(new WindowsServiceApp
{
    Name = "BST.FillrateService",
    TerminalAddress = "10.48.86.235",
    Id = 3,
    Description = "CZ - fillrate service report export",
    State = ServiceState.Unknown,
    CorrectLogAddress = @"C:\Users\bst.produkcja\Desktop\BST\FillrateService\Logs\Correct",
    ErrorLogAddress = @"C:\Users\bst.produkcja\Desktop\BST\FillrateService\Logs\Error"
});

windowsServiceApps.Add(new WindowsServiceApp
{
    Name = "BST.PrintService",
    TerminalAddress = "10.48.86.235",
    Id = 4,
    Description = "CZ - printing documents on warehouse service",
    State = ServiceState.Unknown,
    CorrectLogAddress = @"C:\PrinterService\Logs\Correct",
    ErrorLogAddress = @"C:\PrinterService\Logs\Error"
});

windowsServiceApps.Add(new WindowsServiceApp
{
    Name = "EnovaServer",
    TerminalAddress = "10.48.86.235",
    Id = 5,
    Description = "PL and CZ - enova task scheduler service",
    State = ServiceState.Unknown,
    CorrectLogAddress = string.Empty,
    ErrorLogAddress = string.Empty
});

windowsServiceApps.Add(new WindowsServiceApp
{
    Name = "ImportE3",
    TerminalAddress = "10.48.86.235",
    Id = 6,
    Description = "PL - import E3 data",
    State = ServiceState.Unknown,
    CorrectLogAddress = @"C:\Users\bst.produkcja\Desktop\E3\E3 Logi\Import\Poprawne",
    ErrorLogAddress = @"C:\Users\bst.produkcja\Desktop\E3\E3 Logi\Import\Błędne"
});

windowsServiceApps.Add(new WindowsServiceApp
{
    Name = "BST.IISGuard",
    TerminalAddress = "10.48.86.234",
    Id = 7,
    Description = "PL and CZ - checking iis services",
    State = ServiceState.Unknown,
    CorrectLogAddress = @"C:\Users\bst.produkcja\Desktop\BST\IIS\Log",
    ErrorLogAddress = string.Empty
});

windowsServiceApps.Add(new WindowsServiceApp
{
    Name = "EnovaServer integrator",
    TerminalAddress = "10.48.86.234",
    Id = 8,
    Description = "CZ - data export from enova to helios",
    State = ServiceState.Unknown,
    CorrectLogAddress = string.Empty,
    ErrorLogAddress = string.Empty
});

File.WriteAllText(@"json\services.json", JsonConvert.SerializeObject(windowsServiceApps));

//Scheduler
ICollection<WindowsTaskSchedulerApp> windowsTaskSchedulerApps = new List<WindowsTaskSchedulerApp>();

windowsTaskSchedulerApps.Add(new WindowsTaskSchedulerApp
{
    Name = "Autoksiegowanie faktur",
    TerminalAddress = "10.48.86.235",
    Id = 1,
    Description = "PL - auto-accounting task",
    State = ServiceState.Unknown,
    CorrectLogAddress = "",
    ErrorLogAddress = ""
});

windowsTaskSchedulerApps.Add(new WindowsTaskSchedulerApp
{
    Name = "BST.OperatorReplacementService",
    TerminalAddress = "10.48.86.235",
    Id = 2,
    Description = "PL - calculating enova operators replacements task",
    State = ServiceState.Unknown,
    CorrectLogAddress = "",
    ErrorLogAddress = ""
});

windowsTaskSchedulerApps.Add(new WindowsTaskSchedulerApp
{
    Name = "CZ Blocked products",
    TerminalAddress = "10.48.86.235",
    Id = 3,
    Description = "CZ - sending email with blocked products in 24h task",
    State = ServiceState.Unknown,
    CorrectLogAddress = "",
    ErrorLogAddress = ""
});

windowsTaskSchedulerApps.Add(new WindowsTaskSchedulerApp
{
    Name = "CZ Turnovers calc",
    TerminalAddress = "10.48.86.235",
    Id = 4,
    Description = "PL and CZ - calculating turnovers by article/client task",
    State = ServiceState.Unknown,
    CorrectLogAddress = "",
    ErrorLogAddress = ""
});

windowsTaskSchedulerApps.Add(new WindowsTaskSchedulerApp
{
    Name = "Operator logout",
    TerminalAddress = "10.48.86.235",
    Id = 5,
    Description = "PL - automatic enova operators logout task",
    State = ServiceState.Unknown,
    CorrectLogAddress = "",
    ErrorLogAddress = ""
});

windowsTaskSchedulerApps.Add(new WindowsTaskSchedulerApp
{
    Name = "ZSMOPL",
    TerminalAddress = "10.48.86.235",
    Id = 6,
    Description = "PL - reporting drugs turnovers to gov",
    State = ServiceState.Unknown,
    CorrectLogAddress = "",
    ErrorLogAddress = ""
});

File.WriteAllText(@"json\tasks.json", JsonConvert.SerializeObject(windowsTaskSchedulerApps));