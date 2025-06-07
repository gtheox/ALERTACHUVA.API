using AlertaChuva.API.DTOs;
using AlertaChuva.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AlertaChuva.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SensorController : ControllerBase
{
    private readonly ISensorService _sensorService;

    public SensorController(ISensorService sensorService)
    {
        _sensorService = sensorService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SensorDto>>> Get()
    {
        var sensores = await _sensorService.GetAllAsync();
        return Ok(sensores);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SensorDto>> Get(int id)
    {
        var sensor = await _sensorService.GetByIdAsync(id);
        if (sensor == null)
            return NotFound("Sensor não encontrado.");
        return Ok(sensor);
    }

    [HttpPost]
    public async Task<ActionResult<SensorDto>> Post(SensorDto dto)
    {
        var novo = await _sensorService.CreateAsync(dto);
        return CreatedAtAction(nameof(Get), new { id = novo.Id }, novo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, SensorDto dto)
    {
        if (id != dto.Id)
            return BadRequest("ID inválido.");

        var atualizado = await _sensorService.UpdateAsync(id, dto);
        return atualizado ? NoContent() : NotFound("Sensor não encontrado.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var removido = await _sensorService.DeleteAsync(id);
        return removido ? NoContent() : NotFound("Sensor não encontrado.");
    }
}
