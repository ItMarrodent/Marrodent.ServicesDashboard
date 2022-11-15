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
    private readonly IServiceController _iisController;

    //CTOR
    public IndexModel(ILogger<IndexModel> logger, IConfigurationController configurationController, IServiceController iisController)
    {
        _logger = logger;
        _configurationController = configurationController;
        _iisController = iisController;
    }

    //Public
    public void OnGet()
    {
        Apps = _configurationController.GetAll();
        GetState();
    }
    
    public IActionResult OnPostAction(int id, ActionType type)
    {
        ServiceApp? app = Apps?.FirstOrDefault();
        
        if(app == null) return RedirectToPage("index");

        switch (type)
        {
            case ActionType.Start:
                app.Start();  
                break;
            case ActionType.Restart:
                app.Stop();
                app.Start();
                break;
            case ActionType.Stop:
                app.Stop();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
        
        return RedirectToPage("index");
    }
    
    //Private
    private void GetState()
    {
        foreach (ServiceApp app in Apps)
        {
            if (app.Type == ServiceType.IIS)
            {
                app.State = _iisController.GetState(app.ServiceName);
            }
        }
    }
}