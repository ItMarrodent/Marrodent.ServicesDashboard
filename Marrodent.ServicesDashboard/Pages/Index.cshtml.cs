using Marrodent.ServicesDashboard.Interfaces;
using Marrodent.ServicesDashboard.Models.Abstracts;
using Marrodent.ServicesDashboard.Models.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Marrodent.ServicesDashboard.Pages;

public sealed class IndexModel : PageModel
{
    //Public
    public ICollection<ServiceApp>? Apps { get; set; }
    
    //Private
    private readonly ILogger<IndexModel> _logger;
    private readonly IConfigurationController _configurationController;
    private readonly IWebServiceController _webServiceController;
    private readonly IServiceController _serviceController;

    //CTOR
    public IndexModel(ILogger<IndexModel> logger, IConfigurationController configurationController, IWebServiceController webServiceController, IServiceController serviceController)
    {
        _logger = logger;
        _configurationController = configurationController;
        _webServiceController = webServiceController;
        _serviceController = serviceController;
    }

    //Public
    public async Task OnGet()
    {
        Apps = _configurationController.GetAll(); 
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
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
        
        return RedirectToPage("index");
    }

    //Private
    private void Start(ServiceApp app)
    {
        switch (app.Type)
        {
            case ServiceType.IIS:
                _webServiceController.Start(app.ServiceName);
                break;
            case ServiceType.WindowsService:
                _serviceController.Start(app.WindowsServiceName, app.Address);
                break;
        }
    }

    private void Stop(ServiceApp app)
    {
        switch (app.Type)
        {
            case ServiceType.IIS:
                _webServiceController.Stop(app.ServiceName);
                break;
            case ServiceType.WindowsService:
                _serviceController.Stop(app.WindowsServiceName, app.Address);
                break;
        }
    }

    private async Task GetState()
    {
        await _webServiceController.Refresh();
        _serviceController.Refresh();
        
        foreach (ServiceApp app in Apps)
        {
            app.State = app.Type switch
            {
                ServiceType.IIS => await _webServiceController.GetState(app.ServiceName),
                ServiceType.WindowsService => _serviceController.GetState(app.ServiceName, app.Address),
                _ => app.State
            };
        }
    }
}