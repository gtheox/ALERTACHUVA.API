namespace AlertaChuva.API.Models;

public class Leitura
{
    public int Id { get; set; }

    public int SensorId { get; set; }
    public Sensor Sensor { get; set; } = null!;

    public double NivelAguaCm { get; set; }

    public DateTime DataHora { get; set; } = DateTime.UtcNow;

    // Relacionamento 1:1 (pode não ter alerta)
    public Alerta? Alerta { get; set; }
}
