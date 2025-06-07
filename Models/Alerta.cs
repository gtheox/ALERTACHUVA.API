namespace AlertaChuva.API.Models;

public class Alerta
{
    public int Id { get; set; }

    public int LeituraId { get; set; }
    public Leitura Leitura { get; set; } = null!;

    public double NivelAguaCm { get; set; }

    public DateTime DataHora { get; set; } = DateTime.UtcNow;

    public string Status { get; set; } = "emitido"; // emitido ou resolvido
}
