//Usings

using Marrodent.ServicesDashboard.Models.Enum;
using Marrodent.ServicesDashboard.Models.Models;
using Newtonsoft.Json;

//IIS
ICollection<IISApp> iisApps = new List<IISApp>();

iisApps.Add(new IISApp
{
    ServiceName = "API MARRODENT",
    DisplayName = "Platforma WebService",
    Address = "10.48.86.234:84",
    Id = 1,
    Description = "PL and CZ - Main plaforma and enova connection service",
});

iisApps.Add(new IISApp
{
    ServiceName = "EnovaIntegrator",
    DisplayName = "Enova integrator WebService",
    Address = "10.48.86.234:89",
    Id = 2,
    Description = "CZ - data export from enova to helios",
});

iisApps.Add(new IISApp
{
    ServiceName = "API PRINTING CZ",
    DisplayName = "Printing API",
    Address = "10.48.86.234:90",
    Id = 3,
    Description = "CZ - Invoice printing on demand",
});

iisApps.Add(new IISApp
{
    ServiceName = "RODO",
    DisplayName = "RODO WebService",
    Address = "10.48.86.234:83",
    Id = 4,
    Description = "PL - rodo customer service",
});

iisApps.Add(new IISApp
{
    ServiceName = "API GLOBAL ATTACHMENTS",
    DisplayName = "Global attachments",
    Address = "10.48.86.234:92",
    Id = 5,
    Description = "PL and CZ attachment service",
});

iisApps.Add(new IISApp
{
    ServiceName = "API KHT",
    DisplayName = "KHT PL WebService",
    Address = "10.48.86.234:82",
    Id = 6,
    Description = "PL - old attachment service",
});

iisApps.Add(new IISApp
{
    ServiceName = "API KHT CZ",
    DisplayName = "KHT CZ WebService",
    Address = "10.48.86.234:85",
    Id = 7,
    Description = "CZ - old attachment service",
});

File.WriteAllText(@"json\iis.json", JsonConvert.SerializeObject(iisApps));

//Services
ICollection<WindowsServiceApp> windowsServiceApps = new List<WindowsServiceApp>();

windowsServiceApps.Add(new WindowsServiceApp
{
    ServiceName = "AutomatE3",
    DisplayName = "Export E3",
    Address = @"10.48.86.235 / C:\Program Files (x86)\BST\Marrodent E3",
    Id = 1,
    Description = "PL - export E3 data",
    CorrectLogAddress = @"C:\Users\bst.produkcja\Desktop\E3\E3 Logi\Poprawne",
    ErrorLogAddress = @"C:\Users\bst.produkcja\Desktop\E3\E3 Logi\Błędne"
});

windowsServiceApps.Add(new WindowsServiceApp
{
    ServiceName = "BST.EmailService",
    DisplayName = "Email service",
    Address = @"10.48.86.235 / C:\Program Files (x86)\BST\BST.EmailService",
    Id = 2,
    Description = "CZ - customer email sending service",
    CorrectLogAddress = @"C:\Users\bst.produkcja\Desktop\BST\EmailService\Logs\Correct",
    ErrorLogAddress = @"C:\Users\bst.produkcja\Desktop\BST\EmailService\Logs\Error"
});

windowsServiceApps.Add(new WindowsServiceApp
{
    ServiceName = "BST.FillrateService",
    DisplayName = "Fillrate service",
    Address = @"10.48.86.235 / C:\Program Files (x86)\BST\BST.FillrateService",
    Id = 3,
    Description = "CZ - fillrate service report export",
    CorrectLogAddress = @"C:\Users\bst.produkcja\Desktop\BST\FillrateService\Logs\Correct",
    ErrorLogAddress = @"C:\Users\bst.produkcja\Desktop\BST\FillrateService\Logs\Error"
});

windowsServiceApps.Add(new WindowsServiceApp
{
    ServiceName = "BST.PrintService",
    DisplayName = "Print service",
    Address = @"10.48.86.235 / C:\Program Files (x86)\BST\BST.PrintService",
    Id = 4,
    Description = "CZ - printing documents on warehouse service",
    CorrectLogAddress = @"C:\PrinterService\Logs\Correct",
    ErrorLogAddress = @"C:\PrinterService\Logs\Error"
});

windowsServiceApps.Add(new WindowsServiceApp
{
    ServiceName = "enovaServer",
    DisplayName = "Enova task scheduler",
    Address = @"10.48.86.235 / C:\EnovaServer",
    Id = 5,
    Description = "PL and CZ - enova task scheduler service",
    CorrectLogAddress = string.Empty,
    ErrorLogAddress = string.Empty
});

windowsServiceApps.Add(new WindowsServiceApp
{
    ServiceName = "ImportE3",
    DisplayName = "Import E3",
    Address = @"10.48.86.235 / C:\Program Files (x86)\BST\Import E3",
    Id = 6,
    Description = "PL - import E3 data",
    CorrectLogAddress = @"C:\Users\bst.produkcja\Desktop\E3\E3 Logi\Import\Poprawne",
    ErrorLogAddress = @"C:\Users\bst.produkcja\Desktop\E3\E3 Logi\Import\Błędne"
});

windowsServiceApps.Add(new WindowsServiceApp
{
    ServiceName = "BST.IISGuard",
    DisplayName = "IIS Guard",
    Address = @"10.48.86.234 / C:\Users\bst.produkcja\Desktop\BST\IIS",
    Id = 7,
    Description = "PL and CZ - checking iis services",
    CorrectLogAddress = @"C:\Users\bst.produkcja\Desktop\BST\IIS\Log",
    ErrorLogAddress = string.Empty
});

windowsServiceApps.Add(new WindowsServiceApp
{
    ServiceName = "enovaServer",
    DisplayName = "Enova integrator",
    Address = @"10.48.86.234 / C:\enovaIntegrator",
    Id = 8,
    Description = "CZ - data export from enova to helios",
    CorrectLogAddress = string.Empty,
    ErrorLogAddress = string.Empty
});

windowsServiceApps.Add(new WindowsServiceApp
{
    ServiceName = "BST.WydrukWebService",
    DisplayName = "Wydruk web service",
    Address = @"10.48.86.234 / C:\Program Files (x86)\BST\WydrukWebService",
    Id = 9,
    Description = "PL - correction printing on demand in platforma",
    CorrectLogAddress = string.Empty,
    ErrorLogAddress = string.Empty
});

File.WriteAllText(@"json\services.json", JsonConvert.SerializeObject(windowsServiceApps));

//Scheduler
ICollection<WindowsTaskSchedulerApp> windowsTaskSchedulerApps = new List<WindowsTaskSchedulerApp>();

windowsTaskSchedulerApps.Add(new WindowsTaskSchedulerApp
{
    ServiceName = "Autoksiegowanie faktur",
    DisplayName = "Autoksiegowanie faktur",
    Address = @"10.48.86.235 / C:\ProgramData\BST.AutoKsiegowanie",
    Id = 1,
    Description = "PL - auto-accounting task",
    CorrectLogAddress = @"C:\ProgramData\BST.AutoKsiegowanie",
    ErrorLogAddress = string.Empty
});

windowsTaskSchedulerApps.Add(new WindowsTaskSchedulerApp
{
    ServiceName = "BST.OperatorReplacementService",
    DisplayName = "Operator replacement service",
    Address = @"10.48.86.235 / C:\Program Files (x86)\BST\BST.OperatorReplacementService",
    Id = 2,
    Description = "PL - calculating enova operators replacements task",
    CorrectLogAddress = @"C:\Program Files (x86)\BST\BST.OperatorReplacementService\Log\Correct",
    ErrorLogAddress = @"C:\Program Files (x86)\BST\BST.OperatorReplacementService\Log\Error"
});

windowsTaskSchedulerApps.Add(new WindowsTaskSchedulerApp
{
    ServiceName = "CZ Blocked products",
    DisplayName = "CZ Blocked products",
    Address = @"10.48.86.235 / C:\Program Files (x86)\BST\BST.CzBlockedProductsEmail",
    Id = 3,
    Description = "CZ - sending email with blocked products in 24h task",
    CorrectLogAddress = @"C:\Users\bst.produkcja\Desktop\BST\Blocked products log\Correct",
    ErrorLogAddress = @"C:\Users\bst.produkcja\Desktop\BST\Blocked products log\Error"
});

windowsTaskSchedulerApps.Add(new WindowsTaskSchedulerApp
{
    ServiceName = "CZ Turnovers calc",
    DisplayName = "CZ Turnovers calc",
    Address = @"10.48.86.235 / C:\Program Files (x86)\BST\BST.CzTurnoverCalc",
    Id = 4,
    Description = "PL and CZ - calculating turnovers by article/client task",
    CorrectLogAddress = @"C:\Users\bst.produkcja\Desktop\BST\Turnovers\Correct",
    ErrorLogAddress = @"C:\Users\bst.produkcja\Desktop\BST\Turnovers\Error"
});

windowsTaskSchedulerApps.Add(new WindowsTaskSchedulerApp
{
    ServiceName = "Operator logout",
    DisplayName = "Operator logout",
    Address = @"10.48.86.235 / C:\Program Files (x86)\BST\BST.OperatorLogout",
    Id = 5,
    Description = "PL - automatic enova operators logout task",
    CorrectLogAddress = @"C:\Program Files (x86)\BST\BST.OperatorLogout\Log",
    ErrorLogAddress = string.Empty
});

windowsTaskSchedulerApps.Add(new WindowsTaskSchedulerApp
{
    ServiceName = "ZSMOPL",
    DisplayName = "ZSMOPL",
    Address = @"10.48.86.235 / C:\Program Files (x86)\Soneta\enova365 2112.5.8.0",
    Id = 6,
    Description = "PL - reporting drugs turnovers to gov",
    CorrectLogAddress = @"C:\ProgramData\BST\ZSMOPL",
    ErrorLogAddress = string.Empty
});

File.WriteAllText(@"json\tasks.json", JsonConvert.SerializeObject(windowsTaskSchedulerApps));