using AlertaChuva.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AlertaChuva.API.Data;

public static class SeedData
{
    public static void Inicializar(AppDbContext context)
    {
        context.Database.Migrate();

        if (context.Usuarios.FirstOrDefault() != null) return;

        // Usuários
        var usuarios = new List<Usuario>
        {
            new() { Nome = "Ana Lima", Email = "ana@email.com", Senha = "123", Cidade = "São Paulo", TipoUsuario = "morador" },
            new() { Nome = "Carlos Silva", Email = "carlos@email.com", Senha = "123", Cidade = "Campinas", TipoUsuario = "morador" },
            new() { Nome = "João Mendes", Email = "joao@email.com", Senha = "123", Cidade = "Osasco", TipoUsuario = "admin" }
        };
        context.Usuarios.AddRange(usuarios);
        context.SaveChanges();

        // Sensores
        var sensores = new List<Sensor>
        {
            new() { Localizacao = "Rua A", Status = "ativo", NivelAlertaMinimoCm = 100, UsuarioId = usuarios[0].Id },
            new() { Localizacao = "Rua B", Status = "ativo", NivelAlertaMinimoCm = 150, UsuarioId = usuarios[1].Id }
        };
        context.Sensores.AddRange(sensores);
        context.SaveChanges();

        // Leituras + alertas automáticos
        var leitura1 = new Leitura { SensorId = sensores[0].Id, NivelAguaCm = 120, DataHora = DateTime.UtcNow };
        var leitura2 = new Leitura { SensorId = sensores[1].Id, NivelAguaCm = 90, DataHora = DateTime.UtcNow };
        context.Leituras.AddRange(leitura1, leitura2);
        context.SaveChanges();

        // Alerta automático para leitura acima do limite
        var alerta = new Alerta
        {
            LeituraId = leitura1.Id,
            NivelAguaCm = leitura1.NivelAguaCm,
            DataHora = leitura1.DataHora,
            Status = "emitido"
        };
        context.Alertas.Add(alerta);
        context.SaveChanges();
    }
}
