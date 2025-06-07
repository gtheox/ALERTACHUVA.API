using AlertaChuva.API.Data;
using AlertaChuva.API.DTOs;
using AlertaChuva.API.Models;
using AlertaChuva.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlertaChuva.API.Services.Implementacoes;

public class LeituraService : ILeituraService
{
    private readonly AppDbContext _context;

    public LeituraService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<LeituraDto>> GetAllAsync()
    {
        return await _context.Leituras
            .Select(l => new LeituraDto
            {
                Id = l.Id,
                SensorId = l.SensorId,
                NivelAguaCm = l.NivelAguaCm,
                DataHora = l.DataHora
            })
            .ToListAsync();
    }

    public async Task<LeituraDto?> GetByIdAsync(int id)
    {
        var leitura = await _context.Leituras.FindAsync(id);
        if (leitura == null) return null;

        return new LeituraDto
        {
            Id = leitura.Id,
            SensorId = leitura.SensorId,
            NivelAguaCm = leitura.NivelAguaCm,
            DataHora = leitura.DataHora
        };
    }

    public async Task<LeituraDto> CreateAsync(LeituraDto dto)
    {
        var sensor = await _context.Sensores.FindAsync(dto.SensorId);
        if (sensor == null)
            throw new Exception("Sensor não encontrado.");

        var leitura = new Leitura
        {
            SensorId = dto.SensorId,
            NivelAguaCm = dto.NivelAguaCm,
            DataHora = DateTime.UtcNow
        };

        _context.Leituras.Add(leitura);
        await _context.SaveChangesAsync();

        // Verificar se deve gerar alerta
        if (dto.NivelAguaCm > sensor.NivelAlertaMinimoCm)
        {
            var alerta = new Alerta
            {
                LeituraId = leitura.Id,
                NivelAguaCm = dto.NivelAguaCm,
                DataHora = DateTime.UtcNow,
                Status = "emitido"
            };

            _context.Alertas.Add(alerta);
            await _context.SaveChangesAsync();
        }

        dto.Id = leitura.Id;
        dto.DataHora = leitura.DataHora;
        return dto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var leitura = await _context.Leituras.FindAsync(id);
        if (leitura == null) return false;

        _context.Leituras.Remove(leitura);
        await _context.SaveChangesAsync();
        return true;
    }
}
