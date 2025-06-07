using AlertaChuva.API.DTOs;

namespace AlertaChuva.API.Services.Interfaces;

public interface IAlertaService
{
    Task<IEnumerable<AlertaDto>> GetAllAsync();
    Task<AlertaDto?> GetByIdAsync(int id);
    Task<bool> ResolverAsync(int id);
}
