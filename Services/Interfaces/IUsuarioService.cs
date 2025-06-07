using AlertaChuva.API.DTOs;

namespace AlertaChuva.API.Services.Interfaces;

public interface IUsuarioService
{
    Task<IEnumerable<UsuarioDto>> GetAllAsync();
    Task<UsuarioDto?> GetByIdAsync(int id);
    Task<UsuarioDto> CreateAsync(UsuarioDto dto);
    Task<bool> UpdateAsync(int id, UsuarioDto dto);
    Task<bool> DeleteAsync(int id);
}
