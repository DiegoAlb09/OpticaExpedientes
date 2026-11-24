# Modelo de datos (Fase 1)

Tres entidades: **Paciente** 1 — N **Expediente** 1 — 0..1 **PedidoArmazon**.
Todas heredan de `EntidadBase`: `Id` (Guid), `CreadoEn` y `ActualizadoEn` (UTC).

## Reglas

- No se permite borrar: `AppDbContext` lanza una excepción si se intenta eliminar algo. Las claves foráneas usan `Restrict`.
- `Expediente.Folio` es un entero consecutivo, con índice único.
- Un expediente tiene como máximo un pedido de armazón (índice único en `PedidoArmazon.ExpedienteId`).
- Los valores del examen son texto libre, una columna por celda; `OD` = ojo derecho, `OI` = ojo izquierdo.
- La edad se captura en cada expediente.
- Base de datos: `%LocalAppData%\OpticaExpedientes\optica.db`.
- En la Fase 2 se cifrarán `Paciente.Nombre`, `Domicilio`, `Colonia`, `Ciudad` y `Telefono`.

## Correspondencia con el expediente físico

| Papel | Columnas |
|---|---|
| Nombre, Domicilio, Colonia, Ciudad, Estado, Tel., Ocupación | `Paciente.Nombre/Domicilio/Colonia/Ciudad/Estado/Telefono/Ocupacion` |
| Fecha, Examinó, Edad, Motivo de consulta | `Expediente.Fecha/Examino/Edad/MotivoConsulta` |
| Antecedentes: salud general, alergias, oftalmológicos | `SaludGeneral`, `Alergias`, `AntecedentesOftalmologicos` |
| Prescripción que utiliza: Anteojos / L/C / Ambos / Ninguno | `PrescripcionActualTipo` |
| Prescripción: Lejos, ADD, Lente de contacto, A/V (OD y OI) | `PrescLejosOD/OI`, `PrescAddOD/OI`, `PrescLcOD/OI`, `PrescAvOD/OI` |
| Observaciones | `Observaciones` |
| A/V | `AvOD`, `AvOI` |
| K | `KOD`, `KOI` |
| Esquiascopía | `EsquiascopiaOD/OI` |
| Estenopeico | `EstenopeicoOD/OI` |
| Salud ocular | `SaludOcularOD/OI` |
| Autorefractómetro: Lejos, ADD | `AutorrefLejosOD/OI`, `AutorrefAddOD/OI` |
| Pruebas complementarias (preliminares) | `PruebasComplementarias` |
| Rx Total: Lejos, ADD | `RxTotalLejosOD/OI`, `RxTotalAddOD/OI` |
| Rx Final: Lejos, ADD, A/V | `RxFinalLejosOD/OI`, `RxFinalAddOD/OI`, `RxFinalAvOD/OI` |
| Dx, D.I., A.O. | `Dx`, `DistanciaInterpupilar`, `AlturaOptica` |
| Lente/Contacto: Rx, CB, Ø Diámetro, Tipo/Marca | `LcRx`, `LcCb`, `LcDiametro`, `LcTipoMarca` |
| Presupuesto: Fecha de pedido, Armazón, Plástico, Total, Fecha de entrega | `PedidoArmazon.FechaPedido/PrecioArmazon/PrecioPlastico/Total/FechaEntrega` |
| (nuevo) estado del pedido | `PedidoArmazon.Estado`: Pendiente, Listo, Entregado, Cancelado |

## Supuestos a confirmar contra el papel

- Cada cuadrícula por ojo se guarda como **un solo texto por columna del encabezado** (por ejemplo, `RxFinalLejosOD` guarda esfera, cilindro y eje juntos).
- A.O. se interpretó como altura óptica.
- Armazón y Plástico del presupuesto se guardaron como precios.
- El bloque Lente/Contacto se guardó como un texto por campo, no por ojo.
