using System.IO;

namespace OpticaExpedientes.Data;

public static class AppPaths
{
    /// <summary>%LocalAppData%\OpticaExpedientes (se crea si no existe).</summary>
    public static string DataDirectory { get; } = Directory.CreateDirectory(
        Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "OpticaExpedientes")).FullName;

    public static string DatabasePath { get; } = Path.Combine(DataDirectory, "optica.db");
}
