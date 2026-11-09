using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using wt_lab8_8razor_postgresql_zhiznevskaya.Data;
using wt_lab8_8razor_postgresql_zhiznevskaya.Models;

namespace wt_lab8_8razor_postgresql_zhiznevskaya.Pages.Cars;

public class DeleteModel : PageModel
{
    private readonly AppDbContext _context;

    public DeleteModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Car Car { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        var car = await _context.Cars.FirstOrDefaultAsync(m => m.Id == id);
        if (car == null) return NotFound();

        Car = car;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null) return NotFound();

        var car = await _context.Cars.FindAsync(id);
        if (car != null)
        {
            Car = car;
            _context.Cars.Remove(Car);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}