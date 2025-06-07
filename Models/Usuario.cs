namespace AlertaChuva.API.Models;

public class Usuario
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Senha { get; set; } = string.Empty;

    public string Cidade { get; set; } = string.Empty;

    // Pode ser "admin" ou "morador"
    public string TipoUsuario { get; set; } = "morador";

    // Relacionamento 1:N
    public ICollection<Sensor> Sensores { get; set; } = new List<Sensor>();
}
