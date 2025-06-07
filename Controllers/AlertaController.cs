using AlertaChuva.API.DTOs;
using AlertaChuva.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AlertaChuva.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlertaController : ControllerBase
{
    private readonly IAlertaService _alertaService;

    public AlertaController(IAlertaService alertaService)
    {
        _alertaService = alertaService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AlertaDto>>> Get()
    {
        var alertas = await _alertaService.GetAllAsync();
        return Ok(alertas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AlertaDto>> Get(int id)
    {
        var alerta = await _alertaService.GetByIdAsync(id);
        if (alerta == null)
            return NotFound("Alerta não encontrado.");
        return Ok(alerta);
    }

    [HttpPut("{id}/status")]
    public async Task<IActionResult> Resolver(int id)
    {
        var resolvido = await _alertaService.ResolverAsync(id);
        if (!resolvido)
            return NotFound("Alerta não encontrado ou já resolvido.");
        return Ok("Status do alerta atualizado para resolvido.");
    }
}
