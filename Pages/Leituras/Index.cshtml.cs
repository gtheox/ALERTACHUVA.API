using AlertaChuva.API.Data;
using AlertaChuva.API.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AlertaChuva.API.Pages.Leituras;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public List<Leitura> Leituras { get; set; } = new();

    public async Task OnGetAsync()
    {
        Leituras = await _context.Leituras
            .Include(l => l.Sensor)
            .OrderByDescending(l => l.DataHora)
            .ToListAsync();
    }
}
