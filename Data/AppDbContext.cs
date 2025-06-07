using Microsoft.EntityFrameworkCore;
using AlertaChuva.API.Models;

namespace AlertaChuva.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Sensor> Sensores { get; set; }
    public DbSet<Leitura> Leituras { get; set; }
    public DbSet<Alerta> Alertas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Relacionamento 1:N Usuario → Sensores
        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Sensores)
            .WithOne(s => s.Usuario)
            .HasForeignKey(s => s.UsuarioId);

        // Relacionamento 1:N Sensor → Leituras
        modelBuilder.Entity<Sensor>()
            .HasMany(s => s.Leituras)
            .WithOne(l => l.Sensor)
            .HasForeignKey(l => l.SensorId);

        // Relacionamento 1:1 Leitura → Alerta
        modelBuilder.Entity<Leitura>()
            .HasOne(l => l.Alerta)
            .WithOne(a => a.Leitura)
            .HasForeignKey<Alerta>(a => a.LeituraId);
    }
}
