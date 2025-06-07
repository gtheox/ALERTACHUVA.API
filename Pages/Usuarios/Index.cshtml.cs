using AlertaChuva.API.Data;
using AlertaChuva.API.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AlertaChuva.API.Pages.Usuarios;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public List<Usuario> Usuarios { get; set; } = new();

    public async Task OnGetAsync()
    {
        Usuarios = await _context.Usuarios
            .OrderBy(u => u.Nome)
            .ToListAsync();
    }
}
