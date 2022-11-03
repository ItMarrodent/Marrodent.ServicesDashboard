using Marrodent.ServicesDashboard.Interfaces;
using Marrodent.ServicesDashboard.Models.Abstracts;
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

    //CTOR
    public IndexModel(ILogger<IndexModel> logger, IConfigurationController configurationController)
    {
        _logger = logger;
        _configurationController = configurationController;
    }

    //Public
    public void OnGet()
    {
        Apps = _configurationController.GetAll();
    }
    
    public IActionResult OnPostStart(int id)
    {
        return RedirectToPage("index");
    }
    
    public IActionResult OnPostReset(int id)
    {
        return RedirectToPage("index");
    }
    
    public IActionResult OnPostStop(int id)
    {
        return RedirectToPage("index");
    }
}