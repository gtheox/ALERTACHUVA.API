using AlertaChuva.API.Data;
using AlertaChuva.API.DTOs;
using AlertaChuva.API.Models;
using AlertaChuva.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlertaChuva.API.Services.Implementacoes;

public class AlertaService : IAlertaService
{
    private readonly AppDbContext _context;

    public AlertaService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<AlertaDto>> GetAllAsync()
    {
        return await _context.Alertas
            .Include(a => a.Leitura)
            .OrderByDescending(a => a.DataHora)
            .Select(a => new AlertaDto
            {
                Id = a.Id,
                LeituraId = a.LeituraId,
                NivelAguaCm = a.NivelAguaCm,
                DataHora = a.DataHora,
                Status = a.Status
            })
            .ToListAsync();
    }

    public async Task<AlertaDto?> GetByIdAsync(int id)
    {
        var alerta = await _context.Alertas
            .Include(a => a.Leitura)
            .FirstOrDefaultAsync(a => a.Id == id);

        if (alerta == null) return null;

        return new AlertaDto
        {
            Id = alerta.Id,
            LeituraId = alerta.LeituraId,
            NivelAguaCm = alerta.NivelAguaCm,
            DataHora = alerta.DataHora,
            Status = alerta.Status
        };
    }

    public async Task<bool> ResolverAsync(int id)
    {
        var alerta = await _context.Alertas.FindAsync(id);

        if (alerta == null) return false;
        if (alerta.Status == "resolvido") return false;

        alerta.Status = "resolvido";
        await _context.SaveChangesAsync();
        return true;
    }
}
