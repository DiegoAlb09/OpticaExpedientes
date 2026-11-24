# OpticaExpedientes

Aplicación de escritorio (Windows) para crear y mantener los expedientes de una óptica
(resultados del examen de la vista) con historial por paciente.

> **Estado:** Fase 0 (esqueleto). El inicio de sesión actual es un **marcador de posición**
> y NO es seguro: acepta cualquier contraseña no vacía. La autenticación real y el cifrado
> llegan en la Fase 2. No cargar datos reales de clientes antes de eso.

## Stack

- .NET 10 (LTS) · WPF · WPF UI (Fluent) · MVVM con CommunityToolkit.Mvvm
- Generic Host (`Microsoft.Extensions.Hosting`) para inyección de dependencias
- SQLite + Entity Framework Core (Fase 1)
- Pruebas: xUnit

## Requisitos

- Windows 10/11
- [.NET 10 SDK](https://dotnet.microsoft.com/download) (ver `global.json`)
- Visual Studio 2022 17.13+ (o superior) o JetBrains Rider, con la carga de trabajo de escritorio .NET

## Ejecutar

```powershell
dotnet restore
dotnet build
dotnet run --project src/OpticaExpedientes
dotnet test
```

## Estructura

```
src/OpticaExpedientes/
├── App.xaml(.cs)        arranque, Host y registro de servicios
├── Models/              entidades (Paciente, Expediente, PedidoArmazon)
├── Data/                DbContext, configuraciones y migraciones
├── Services/            Security, Backup, Navigation
├── ViewModels/          un ViewModel por vista
├── Views/               ventanas y Pages
├── Converters/  Helpers/  Resources/
tests/OpticaExpedientes.Tests/
docs/decisiones.md       decisiones técnicas tomadas
```

## Fases

| Fase | Entrega |
|---|---|
| 0 | Esqueleto, navegación, tema de Windows, CI |
| 1 | Modelo de datos y SQLite |
| 2 | Seguridad: cifrado de campos, clave de recuperación, login real |
| 3 | Home: recientes, búsqueda y filtros |
| 4 | Nuevo expediente (flujo y pestañas) |
| 5 | Detalle del paciente e historial |
| 6 | Pedidos de armazón |
| 7 | Respaldo local automático y manual |
| 8 | Configuración |
| 9 | Pulido e instalador |

El envío del respaldo por correo se hará después de la Fase 9.
