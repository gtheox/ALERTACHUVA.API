using AlertaChuva.API.DTOs;

namespace AlertaChuva.API.Services.Interfaces;

public interface ILeituraService
{
    Task<IEnumerable<LeituraDto>> GetAllAsync();
    Task<LeituraDto?> GetByIdAsync(int id);
    Task<LeituraDto> CreateAsync(LeituraDto dto); // já inclui geração de alerta
    Task<bool> DeleteAsync(int id);
}
