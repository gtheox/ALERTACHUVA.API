using AlertaChuva.API.Data;
using AlertaChuva.API.DTOs;
using AlertaChuva.API.Models;
using AlertaChuva.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlertaChuva.API.Services.Implementacoes;

public class SensorService : ISensorService
{
    private readonly AppDbContext _context;

    public SensorService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<SensorDto>> GetAllAsync()
    {
        return await _context.Sensores
            .Select(s => new SensorDto
            {
                Id = s.Id,
                Localizacao = s.Localizacao,
                Status = s.Status,
                NivelAlertaMinimoCm = s.NivelAlertaMinimoCm,
                UsuarioId = s.UsuarioId
            })
            .ToListAsync();
    }

    public async Task<SensorDto?> GetByIdAsync(int id)
    {
        var sensor = await _context.Sensores.FindAsync(id);
        if (sensor == null) return null;

        return new SensorDto
        {
            Id = sensor.Id,
            Localizacao = sensor.Localizacao,
            Status = sensor.Status,
            NivelAlertaMinimoCm = sensor.NivelAlertaMinimoCm,
            UsuarioId = sensor.UsuarioId
        };
    }

    public async Task<SensorDto> CreateAsync(SensorDto dto)
    {
        var sensor = new Sensor
        {
            Localizacao = dto.Localizacao,
            Status = dto.Status,
            NivelAlertaMinimoCm = dto.NivelAlertaMinimoCm,
            UsuarioId = dto.UsuarioId
        };

        _context.Sensores.Add(sensor);
        await _context.SaveChangesAsync();

        dto.Id = sensor.Id;
        return dto;
    }

    public async Task<bool> UpdateAsync(int id, SensorDto dto)
    {
        var sensor = await _context.Sensores.FindAsync(id);
        if (sensor == null) return false;

        sensor.Localizacao = dto.Localizacao;
        sensor.Status = dto.Status;
        sensor.NivelAlertaMinimoCm = dto.NivelAlertaMinimoCm;
        sensor.UsuarioId = dto.UsuarioId;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var sensor = await _context.Sensores.FindAsync(id);
        if (sensor == null) return false;

        _context.Sensores.Remove(sensor);
        await _context.SaveChangesAsync();
        return true;
    }
}
