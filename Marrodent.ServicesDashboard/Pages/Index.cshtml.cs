using System.Diagnostics;
using System.IO.Compression;
using Marrodent.ServicesDashboard.Interfaces;
using Marrodent.ServicesDashboard.Models.Abstracts;
using Marrodent.ServicesDashboard.Models.Enum;
using Marrodent.ServicesDashboard.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Marrodent.ServicesDashboard.Pages;

public sealed class IndexModel : PageModel
{
    //Public
    public ICollection<ServiceApp>? Apps { get; set; }
    public ICollection<Terminal>? Terminals { get; set; }

    //Private
    private readonly IConfigurationController _configurationController;
    private readonly IWebServiceController _webServiceController;
    private readonly IServiceController _serviceController;
    private readonly ILogController _logController;

    //CTOR
    public IndexModel(IConfigurationController configurationController, IWebServiceController webServiceController, IServiceController serviceController, ILogController logController)
    {
        _configurationController = configurationController;
        _webServiceController = webServiceController;
        _serviceController = serviceController;
        _logController = logController;
    }

    //Public
    public async Task OnGet()
    {
        Apps = _configurationController.GetAll();
        Terminals = _configurationController.GetTerminals();
        await GetState();
    }

    public IActionResult OnPostAction(int id, ActionType type)
    {
        Apps ??= _configurationController.GetAll();
        ServiceApp? app = Apps?.FirstOrDefault(x=>x.Id == id);
        
        if(app == null) return RedirectToPage("index");

        switch (type)
        {
            case ActionType.Start:
                Start(app);  
                break;
            case ActionType.Restart:
                Stop(app);
                Start(app);
                break;
            case ActionType.Stop:
                Stop(app);
                break;
            case ActionType.Log:
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
        
        return RedirectToPage("index");
    }

    public FileResult OnPostDownloadFile(int id, ActionType type)
    {
        Apps ??= _configurationController.GetAll();
        ServiceApp? app = Apps?.FirstOrDefault(x=>x.Id == id);
        var files = _logController.GetLogs(app);
        var zipName = $"{app.ServiceName}-{DateTime.Now:yyyy_MM_dd-HH_mm_ss}.zip";

        using MemoryStream ms = new MemoryStream();

        using (var zip = new ZipArchive(ms, ZipArchiveMode.Create, true))
        {
            foreach (var file in files.Select(x=> new FileInfo(x)))
            {
                var entry = zip.CreateEntry(file.Name);
                using var fileStream = new MemoryStream(System.IO.File.ReadAllBytes(file.FullName));
                using var entryStream = entry.Open();
                fileStream.CopyTo(entryStream);
            }
        } 
        return File( ms.ToArray(), "application/zip", zipName);
    }

    //Private
    private void Start(ServiceApp app)
    {
        switch (app.Type)
        {
            case ServiceType.IIS:
                _webServiceController.Start(app.Address, app.ServiceName);
                Thread.Sleep(2000);
                break;
            case ServiceType.WindowsService:
                _serviceController.Start(app.WindowsServiceName, app.Address);
                break;
            default:
                break;
        }
    }

    private void Stop(ServiceApp app)
    {
        switch (app.Type)
        {
            case ServiceType.IIS:
                _webServiceController.Stop(app.Address, app.ServiceName);
                Thread.Sleep(2000);
                break;
            case ServiceType.WindowsService:
                _serviceController.Stop(app.WindowsServiceName, app.Address);
                break;
            default:
                break;
        }
    }

    private async Task GetState()
    {
        await _webServiceController.Refresh();
        _serviceController.Refresh();
        
        foreach (ServiceApp app in Apps)
        {
            app.Errors = _logController.HasErrorsToday(app) ? "Yes" : "No";

            app.State = app.Type switch
            {
                ServiceType.IIS => await _webServiceController.GetState(app.ServiceName),
                ServiceType.WindowsService => _serviceController.GetState(app.ServiceName, app.Address),
                ServiceType.WindowsTaskScheduler => app.Errors == "No" ? ServiceState.Running : ServiceState.Unknown,
                _ => app.State
            };
        }

        foreach (Terminal terminal in Terminals)
        {
            PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes", string.Empty, terminal.Address);
            terminal.AvailableRam = Convert.ToDouble(ramCounter.NextValue());

            PerformanceCounter diskCounter = new PerformanceCounter("LogicalDisk", "Free Megabytes", "_total", terminal.Address);
            terminal.AvailableDiskSpace = Convert.ToDouble(diskCounter.NextValue());
        }
    }
}