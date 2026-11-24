namespace OpticaExpedientes.Models;

/// <summary>Bloque "Presupuesto" del expediente físico. Un expediente tiene 0 o 1 pedido.</summary>
public class PedidoArmazon : EntidadBase
{
  public Guid ExpedienteId { get; set; }

  public Expediente Expediente { get; set; } = null!;

  public DateOnly FechaPedido { get; set; }

  public decimal PrecioArmazon { get; set; }

  public decimal PrecioPlastico { get; set; }

  public decimal Total { get; set; }

  public DateOnly? FechaEntrega { get; set; }

  public EstadoPedido Estado { get; set; } = EstadoPedido.Pendiente;
}
