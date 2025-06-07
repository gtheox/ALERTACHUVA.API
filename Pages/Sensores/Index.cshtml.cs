using AlertaChuva.API.Data;
using AlertaChuva.API.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AlertaChuva.API.Pages.Sensores;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public List<Sensor> Sensores { get; set; } = new();

    public async Task OnGetAsync()
    {
        Sensores = await _context.Sensores
            .Include(s => s.Usuario)
            .OrderBy(s => s.Id)
            .ToListAsync();
    }
}
