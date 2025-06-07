using AlertaChuva.API.DTOs;
using AlertaChuva.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AlertaChuva.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LeituraController : ControllerBase
{
    private readonly ILeituraService _leituraService;

    public LeituraController(ILeituraService leituraService)
    {
        _leituraService = leituraService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LeituraDto>>> Get()
    {
        var leituras = await _leituraService.GetAllAsync();
        return Ok(leituras);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LeituraDto>> Get(int id)
    {
        var leitura = await _leituraService.GetByIdAsync(id);
        if (leitura == null)
            return NotFound("Leitura não encontrada.");
        return Ok(leitura);
    }

    [HttpPost]
    public async Task<ActionResult<LeituraDto>> Post(LeituraDto dto)
    {
        var novaLeitura = await _leituraService.CreateAsync(dto);
        return CreatedAtAction(nameof(Get), new { id = novaLeitura.Id }, novaLeitura);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var removida = await _leituraService.DeleteAsync(id);
        return removida ? NoContent() : NotFound("Leitura não encontrada.");
    }
}
