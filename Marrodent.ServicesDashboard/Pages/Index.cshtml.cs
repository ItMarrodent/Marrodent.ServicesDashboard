using Marrodent.ServicesDashboard.Models.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Marrodent.ServicesDashboard.Pages;

public sealed class IndexModel : PageModel
{
    //Public
    public ICollection<IISApp> IISApps { get; set; }
    public ICollection<WindowsServiceApp> WindowsServiceApps { get; set; }
    public ICollection<WindowsTaskSchedulerApp> WindowsTaskSchedulerApps { get; set; }
    public ICollection<OtherApp> OtherApps { get; set; }

    //Private
    private readonly ILogger<IndexModel> _logger;

    //CTOR
    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    //Public
    public void OnGet()
    {
        IISApps = new List<IISApp>();
        WindowsServiceApps = new List<WindowsServiceApp>();
        WindowsTaskSchedulerApps = new List<WindowsTaskSchedulerApp>();
        OtherApps = new List<OtherApp>();
    }
}