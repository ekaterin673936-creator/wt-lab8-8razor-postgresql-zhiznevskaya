using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wt_lab8_8razor_postgresql_zhiznevskaya.Data;
using wt_lab8_8razor_postgresql_zhiznevskaya.Models;

namespace wt_lab8_8razor_postgresql_zhiznevskaya.Pages.Cars;

public class CreateModel : PageModel
{
    private readonly AppDbContext _context;

    public CreateModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Car Car { get; set; } = new();

    public IActionResult OnGet()
    {
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Cars.Add(Car);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}