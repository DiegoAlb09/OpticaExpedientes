namespace OpticaExpedientes.Models;

/// <summary>
/// Identidad y contacto del paciente. En la Fase 2 se cifrarán Nombre, Domicilio,
/// Colonia, Ciudad y Telefono.
/// </summary>
public class Paciente : EntidadBase
{
  public string Nombre { get; set; } = string.Empty;

  public string? Domicilio { get; set; }

  public string? Colonia { get; set; }

  public string? Ciudad { get; set; }

  public string? Estado { get; set; }

  public string? Telefono { get; set; }

  public string? Ocupacion { get; set; }

  public ICollection<Expediente> Expedientes { get; set; } = [];
}
