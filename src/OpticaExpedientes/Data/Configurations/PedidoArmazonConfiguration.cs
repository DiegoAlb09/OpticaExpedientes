using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpticaExpedientes.Models;

namespace OpticaExpedientes.Data.Configurations;

public sealed class PedidoArmazonConfiguration : IEntityTypeConfiguration<PedidoArmazon>
{
    public void Configure(EntityTypeBuilder<PedidoArmazon> builder)
    {
        builder.ToTable("PedidosArmazon");
        builder.HasKey(p => p.Id);

        // Un expediente tiene como máximo un pedido.
        builder.HasIndex(p => p.ExpedienteId).IsUnique();
        builder.HasIndex(p => p.Estado);
        builder.HasIndex(p => p.FechaEntrega);

        builder.Property(p => p.Estado)
            .HasConversion<string>()
            .HasMaxLength(20);
    }
}
