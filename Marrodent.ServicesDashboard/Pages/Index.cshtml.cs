using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Marrodent.ServicesDashboard.Pages;

public sealed class IndexModel : PageModel
{
    //Private
    private readonly ILogger<IndexModel> _logger;

    //CTOR
    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        _
    }

    //Public
    public void OnGet()
    {
    }
}