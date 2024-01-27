using Microsoft.AspNetCore.Mvc.RazorPages;

namespace barber.Pages;

public class IndexModel : PageModel
{
    private readonly Microsoft.Extensions.Logging.ILogger<IndexModel> _logger;

    public IndexModel(Microsoft.Extensions.Logging.ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
