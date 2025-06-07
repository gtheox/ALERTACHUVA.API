namespace AlertaChuva.API.DTOs;

public class UsuarioDto
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Senha { get; set; } = string.Empty;

    public string Cidade { get; set; } = string.Empty;

    public string TipoUsuario { get; set; } = "morador";
}
