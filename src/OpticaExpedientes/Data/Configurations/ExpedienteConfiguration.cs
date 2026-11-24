using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpticaExpedientes.Models;

namespace OpticaExpedientes.Data.Configurations;

public sealed class ExpedienteConfiguration : IEntityTypeConfiguration<Expediente>
{
    public void Configure(EntityTypeBuilder<Expediente> builder)
    {
        builder.ToTable("Expedientes");
        builder.HasKey(e => e.Id);

        builder.HasIndex(e => e.Folio).IsUnique();
        builder.HasIndex(e => e.Fecha);
        builder.HasIndex(e => e.PacienteId);

        builder.Property(e => e.PrescripcionActualTipo)
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.HasOne(e => e.Pedido)
            .WithOne(p => p.Expediente)
            .HasForeignKey<PedidoArmazon>(p => p.ExpedienteId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
