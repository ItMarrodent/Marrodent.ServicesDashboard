using Marrodent.ServicesDashboard.Interfaces;
using Marrodent.ServicesDashboard.Models.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Marrodent.ServicesDashboard.Pages;

public sealed class IndexModel : PageModel
{
    //Public
    public ICollection<IISApp>? IisApps { get; set; }
    public ICollection<WindowsServiceApp>? WindowsServiceApps { get; set; }
    public ICollection<WindowsTaskSchedulerApp>? WindowsTaskSchedulerApps { get; set; }

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
        IisApps = _configurationController.GetIisApps();
        WindowsServiceApps = _configurationController.GetwWindowsServiceApps();
        WindowsTaskSchedulerApps = _configurationController.GetWindowsTaskSchedulerApps();
    }
}