namespace OpticaExpedientes.Models;

/// <summary>Prescripción que utiliza el paciente al llegar: Anteojos, L/C, Ambos o Ninguno.</summary>
public enum TipoPrescripcion
{
  Ninguno = 0,
  Anteojos = 1,
  LenteContacto = 2,
  Ambos = 3,
}
