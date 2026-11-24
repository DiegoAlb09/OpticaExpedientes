namespace OpticaExpedientes.Models;

/// <summary>
/// Una visita/examen. Los valores por ojo (OD = ojo derecho, OI = ojo izquierdo) son texto
/// libre, una columna por cada celda del expediente físico.
/// </summary>
public class Expediente : EntidadBase
{
  // --- Encabezado ---
  public Guid PacienteId { get; set; }

  public Paciente Paciente { get; set; } = null!;

  /// <summary>Número consecutivo visible del expediente.</summary>
  public int Folio { get; set; }

  public DateOnly Fecha { get; set; }

  public string? Examino { get; set; }

  public int? Edad { get; set; }

  public string? MotivoConsulta { get; set; }

  // --- Antecedentes ---
  public string? SaludGeneral { get; set; }

  public string? Alergias { get; set; }

  public string? AntecedentesOftalmologicos { get; set; }

  // --- Prescripción que utiliza ---
  public TipoPrescripcion PrescripcionActualTipo { get; set; } = TipoPrescripcion.Ninguno;

  public string? PrescLejosOD { get; set; }
  public string? PrescLejosOI { get; set; }
  public string? PrescAddOD { get; set; }
  public string? PrescAddOI { get; set; }
  public string? PrescLcOD { get; set; }
  public string? PrescLcOI { get; set; }
  public string? PrescAvOD { get; set; }
  public string? PrescAvOI { get; set; }

  public string? Observaciones { get; set; }

  // --- Examen (reverso) ---
  public string? AvOD { get; set; }
  public string? AvOI { get; set; }

  public string? KOD { get; set; }
  public string? KOI { get; set; }

  public string? EsquiascopiaOD { get; set; }
  public string? EsquiascopiaOI { get; set; }

  public string? EstenopeicoOD { get; set; }
  public string? EstenopeicoOI { get; set; }

  public string? SaludOcularOD { get; set; }
  public string? SaludOcularOI { get; set; }

  public string? AutorrefLejosOD { get; set; }
  public string? AutorrefLejosOI { get; set; }
  public string? AutorrefAddOD { get; set; }
  public string? AutorrefAddOI { get; set; }

  public string? PruebasComplementarias { get; set; }

  public string? RxTotalLejosOD { get; set; }
  public string? RxTotalLejosOI { get; set; }
  public string? RxTotalAddOD { get; set; }
  public string? RxTotalAddOI { get; set; }

  public string? RxFinalLejosOD { get; set; }
  public string? RxFinalLejosOI { get; set; }
  public string? RxFinalAddOD { get; set; }
  public string? RxFinalAddOI { get; set; }
  public string? RxFinalAvOD { get; set; }
  public string? RxFinalAvOI { get; set; }

  public string? Dx { get; set; }

  /// <summary>D.I. del expediente físico.</summary>
  public string? DistanciaInterpupilar { get; set; }

  /// <summary>A.O. del expediente físico.</summary>
  public string? AlturaOptica { get; set; }

  // --- Lente de contacto ---
  public string? LcRx { get; set; }
  public string? LcCb { get; set; }
  public string? LcDiametro { get; set; }
  public string? LcTipoMarca { get; set; }

  // --- Pedido de armazón (0 o 1) ---
  public PedidoArmazon? Pedido { get; set; }
}
