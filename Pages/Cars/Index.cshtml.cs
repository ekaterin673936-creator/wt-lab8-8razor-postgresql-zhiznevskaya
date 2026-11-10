using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using wt_lab8_8razor_postgresql_zhiznevskaya.Data;
using wt_lab8_8razor_postgresql_zhiznevskaya.Models;

namespace wt_lab8_8razor_postgresql_zhiznevskaya.Pages.Cars;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public List<Car> Cars { get; set; } = new();

    // Свойство для поиска
    [BindProperty(SupportsGet = true)]
    public string? Search { get; set; }

    public async Task OnGetAsync()
    {
        var query = _context.Cars.AsQueryable();
        
        if (!string.IsNullOrWhiteSpace(Search))
        {
            query = query.Where(c => c.Brand.Contains(Search) || c.Model.Contains(Search));
        }

        Cars = await query.ToListAsync();
    }
}