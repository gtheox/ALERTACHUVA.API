namespace AlertaChuva.API.Models;

public class Sensor
{
    public int Id { get; set; }

    public string Localizacao { get; set; } = string.Empty;

    public string Status { get; set; } = "ativo"; // ativo ou inativo

    public double NivelAlertaMinimoCm { get; set; }

    // FK
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; } = null!;

    // Relacionamento 1:N
    public ICollection<Leitura> Leituras { get; set; } = new List<Leitura>();
}
