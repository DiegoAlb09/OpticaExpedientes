using Microsoft.EntityFrameworkCore;
using OpticaExpedientes.Models;

namespace OpticaExpedientes.Data;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Paciente> Pacientes => Set<Paciente>();

    public DbSet<Expediente> Expedientes => Set<Expediente>();

    public DbSet<PedidoArmazon> PedidosArmazon => Set<PedidoArmazon>();

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        PrepareChanges();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(
        bool acceptAllChangesOnSuccess,
        CancellationToken cancellationToken = default)
    {
        PrepareChanges();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    /// <summary>
    /// Regla del negocio: no se permite borrar registros, solo editarlos.
    /// Además estampa las fechas de creación y modificación (UTC).
    /// </summary>
    private void PrepareChanges()
    {
        var entries = ChangeTracker.Entries<EntidadBase>().ToList();

        if (entries.Any(e => e.State == EntityState.Deleted))
        {
            throw new InvalidOperationException(
                "No se permite eliminar registros; solo se pueden editar.");
        }

        var now = DateTime.UtcNow;

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreadoEn = now;
                entry.Entity.ActualizadoEn = now;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.ActualizadoEn = now;
                entry.Property(e => e.CreadoEn).IsModified = false;
            }
        }
    }
}
