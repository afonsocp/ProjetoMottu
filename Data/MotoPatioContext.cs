using Microsoft.EntityFrameworkCore;

public class MotoPatioContext : DbContext
{
    public MotoPatioContext(DbContextOptions<MotoPatioContext> options)
        : base(options)
    {
    }

    public required DbSet<Moto> Motos { get; set; }
    public required DbSet<Localizacao> Localizacoes { get; set; }
    public required DbSet<Usuario> Usuarios { get; set; }
    public required DbSet<Manutencao> Manutencoes { get; set; }
    public required DbSet<Reserva> Reservas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Moto>()
            .HasOne(m => m.Localizacao)
            .WithMany(l => l.Motos)
            .HasForeignKey(m => m.ID_Localizacao);

        modelBuilder.Entity<Manutencao>()
            .HasOne(m => m.Moto)
            .WithMany(m => m.Manutencoes)
            .HasForeignKey(m => m.ID_Moto);

        modelBuilder.Entity<Reserva>()
            .HasOne(r => r.Moto)
            .WithMany(m => m.Reservas)
            .HasForeignKey(r => r.ID_Moto);

        modelBuilder.Entity<Reserva>()
            .HasOne(r => r.Usuario)
            .WithMany(u => u.Reservas)
            .HasForeignKey(r => r.ID_Usuario);

        // Configurando a unicidade da placa
        modelBuilder.Entity<Moto>()
            .HasIndex(m => m.Placa)
            .IsUnique();
    }
}