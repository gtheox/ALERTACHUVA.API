using AlertaChuva.API.DTOs;

namespace AlertaChuva.API.Services.Interfaces;

public interface ISensorService
{
    Task<IEnumerable<SensorDto>> GetAllAsync();
    Task<SensorDto?> GetByIdAsync(int id);
    Task<SensorDto> CreateAsync(SensorDto dto);
    Task<bool> UpdateAsync(int id, SensorDto dto);
    Task<bool> DeleteAsync(int id);
}
