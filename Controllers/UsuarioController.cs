using AlertaChuva.API.DTOs;
using AlertaChuva.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AlertaChuva.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UsuarioDto>>> Get()
    {
        var usuarios = await _usuarioService.GetAllAsync();
        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UsuarioDto>> Get(int id)
    {
        var usuario = await _usuarioService.GetByIdAsync(id);
        if (usuario == null)
            return NotFound("Usuário não encontrado.");
        return Ok(usuario);
    }

    [HttpPost]
    public async Task<ActionResult<UsuarioDto>> Post(UsuarioDto dto)
    {
        // Agora o DTO deve conter nome, email, cidade, tipoUsuario E senha
        var novo = await _usuarioService.CreateAsync(dto);
        return CreatedAtAction(nameof(Get), new { id = novo.Id }, novo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, UsuarioDto dto)
    {
        if (id != dto.Id)
            return BadRequest("ID inválido.");

        var atualizado = await _usuarioService.UpdateAsync(id, dto);
        return atualizado ? NoContent() : NotFound("Usuário não encontrado.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var removido = await _usuarioService.DeleteAsync(id);
        return removido ? NoContent() : NotFound("Usuário não encontrado.");
    }
}
