using AlertaChuva.API.Data;
using AlertaChuva.API.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AlertaChuva.API.Pages.Alertas;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public List<Alerta> Alertas { get; set; } = new();

    public async Task OnGetAsync()
    {
        Alertas = await _context.Alertas
            .Include(a => a.Leitura)
            .OrderByDescending(a => a.DataHora)
            .ToListAsync();
    }
}
