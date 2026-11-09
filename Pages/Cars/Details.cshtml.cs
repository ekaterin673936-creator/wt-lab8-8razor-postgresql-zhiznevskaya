using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using wt_lab8_8razor_postgresql_zhiznevskaya.Data;
using wt_lab8_8razor_postgresql_zhiznevskaya.Models;

namespace wt_lab8_8razor_postgresql_zhiznevskaya.Pages.Cars;

public class DetailsModel : PageModel
{
    private readonly AppDbContext _context;

    public DetailsModel(AppDbContext context)
    {
        _context = context;
    }

    public Car? Car { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Car = await _context.Cars.FirstOrDefaultAsync(m => m.Id == id);
        if (Car == null) return NotFound();
        return Page();
    }
}