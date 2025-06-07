namespace AlertaChuva.API.DTOs;

public class LeituraDto
{
    public int Id { get; set; }

    public int SensorId { get; set; }

    public double NivelAguaCm { get; set; }

    public DateTime DataHora { get; set; }
}
