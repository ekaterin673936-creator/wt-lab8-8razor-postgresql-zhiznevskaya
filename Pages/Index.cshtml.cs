using Microsoft.AspNetCore.Mvc.RazorPages;

namespace wt_lab8_8razor_postgresql_zhiznevskaya.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}