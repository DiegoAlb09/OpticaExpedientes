namespace OpticaExpedientes.Models;

/// <summary>Base de todas las entidades: Guid secuencial y marcas de auditoría (UTC).</summary>
public abstract class EntidadBase
{
  public Guid Id { get; set; } = Guid.CreateVersion7();

  public DateTime CreadoEn { get; set; }

  public DateTime ActualizadoEn { get; set; }
}
