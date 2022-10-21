using Marrodent.ServicesDashboard.Models.Enum;
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
        IISApps = new List<IISApp>
        {
            new IISApp
            {
                Name = "Platforma",
                TerminalAddress = "10.48.86.234:84",
                Description = "XYZ",
                State = ServiceState.Running,
                Id = 1
            },
            new IISApp
            {
                Name = "RODO",
                TerminalAddress = "10.48.86.234:83",
                Description = "XYZ",
                State = ServiceState.Stopped,
                Id = 2
            },
            new IISApp
            {
                Name = "KHT PL",
                TerminalAddress = "10.48.86.234:85",
                Description = "XYZ",
                State = ServiceState.Running,
                Id = 3
            },
            new IISApp
            {
                Name = "KHT CZ",
                TerminalAddress = "10.48.86.234:86",
                Description = "XYZ",
                State = ServiceState.Running,
                Id = 4
            },
            new IISApp
            {
                Name = "GLOBAL ATTACHEMENTS",
                TerminalAddress = "10.48.86.234:82",
                Description = "XYZ",
                State = ServiceState.Disabled,
                Id = 5
            }
        };

        WindowsServiceApps = new List<WindowsServiceApp>();
        WindowsTaskSchedulerApps = new List<WindowsTaskSchedulerApp>();
        OtherApps = new List<OtherApp>();
    }
}