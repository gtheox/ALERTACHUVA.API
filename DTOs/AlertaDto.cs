namespace AlertaChuva.API.DTOs;

public class AlertaDto
{
    public int Id { get; set; }

    public int LeituraId { get; set; }

    public double NivelAguaCm { get; set; }

    public DateTime DataHora { get; set; }

    public string Status { get; set; } = "emitido";
}
