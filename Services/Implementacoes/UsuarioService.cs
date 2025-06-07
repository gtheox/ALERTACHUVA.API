using AlertaChuva.API.Data;
using AlertaChuva.API.DTOs;
using AlertaChuva.API.Models;
using AlertaChuva.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlertaChuva.API.Services.Implementacoes;

public class UsuarioService : IUsuarioService
{
    private readonly AppDbContext _context;

    public UsuarioService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UsuarioDto>> GetAllAsync()
    {
        return await _context.Usuarios
            .Select(u => new UsuarioDto
            {
                Id = u.Id,
                Nome = u.Nome,
                Email = u.Email,
                Senha = u.Senha,
                Cidade = u.Cidade,
                TipoUsuario = u.TipoUsuario
            })
            .ToListAsync();
    }

    public async Task<UsuarioDto?> GetByIdAsync(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);

        if (usuario == null) return null;

        return new UsuarioDto
        {
            Id = usuario.Id,
            Nome = usuario.Nome,
            Email = usuario.Email,
            Senha = usuario.Senha,
            Cidade = usuario.Cidade,
            TipoUsuario = usuario.TipoUsuario
        };
    }

    public async Task<UsuarioDto> CreateAsync(UsuarioDto dto)
    {
        var usuario = new Usuario
        {
            Nome = dto.Nome,
            Email = dto.Email,
            Senha = dto.Senha, // agora usando a senha do DTO
            Cidade = dto.Cidade,
            TipoUsuario = dto.TipoUsuario
        };

        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();

        dto.Id = usuario.Id;
        return dto;
    }

    public async Task<bool> UpdateAsync(int id, UsuarioDto dto)
    {
        var usuario = await _context.Usuarios.FindAsync(id);

        if (usuario == null) return false;

        usuario.Nome = dto.Nome;
        usuario.Email = dto.Email;
        usuario.Senha = dto.Senha;
        usuario.Cidade = dto.Cidade;
        usuario.TipoUsuario = dto.TipoUsuario;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);

        if (usuario == null) return false;

        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();
        return true;
    }
}
