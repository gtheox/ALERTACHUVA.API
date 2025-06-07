namespace AlertaChuva.API.DTOs;

public class SensorDto
{
    public int Id { get; set; }

    public string Localizacao { get; set; } = string.Empty;

    public string Status { get; set; } = "ativo";

    public double NivelAlertaMinimoCm { get; set; }

    public int UsuarioId { get; set; }
}
