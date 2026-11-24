using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpticaExpedientes.Data;
using OpticaExpedientes.Services.Navigation;
using OpticaExpedientes.ViewModels;
using OpticaExpedientes.Views;
using OpticaExpedientes.Views.Pages;
using Wpf.Ui.Abstractions;
using Wpf.Ui.Appearance;

namespace OpticaExpedientes;

public partial class App : Application
{
  private IHost? _host;

  public App()
  {
    DispatcherUnhandledException += (_, e) =>
    {
      ShowFatal(e.Exception);
      e.Handled = true;
    };
  }

  protected override async void OnStartup(StartupEventArgs e)
  {
    base.OnStartup(e);

    try
    {
      var builder = Host.CreateApplicationBuilder();
      ConfigureServices(builder.Services);
      _host = builder.Build();
      await _host.StartAsync();

      await MigrateDatabaseAsync(_host.Services);

      ApplicationThemeManager.ApplySystemTheme();

      _host.Services.GetRequiredService<LoginWindow>().Show();
    }
    catch (Exception ex)
    {
      ShowFatal(ex);
      Shutdown(1);
    }
  }

  protected override async void OnExit(ExitEventArgs e)
  {
    if (_host is not null)
    {
      await _host.StopAsync();
      _host.Dispose();
    }

    base.OnExit(e);
  }

  private static async Task MigrateDatabaseAsync(IServiceProvider services)
  {
    var factory = services.GetRequiredService<IDbContextFactory<AppDbContext>>();
    await using var db = await factory.CreateDbContextAsync();
    await db.Database.MigrateAsync();
  }

  private static void ShowFatal(Exception ex) =>
      MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);

  private static void ConfigureServices(IServiceCollection services)
  {
    // Datos
    services.AddDbContextFactory<AppDbContext>(options =>
        options.UseSqlite($"Data Source={AppPaths.DatabasePath}"));

    // Navegación
    services.AddSingleton<INavigationViewPageProvider, ServiceProviderPageProvider>();

    // Ventanas
    services.AddTransient<LoginWindow>();
    services.AddTransient<ShellWindow>();

    // Páginas
    services.AddTransient<HomePage>();
    services.AddTransient<NuevoExpedientePage>();
    services.AddTransient<PacienteDetallePage>();
    services.AddTransient<ConfiguracionPage>();

    // ViewModels
    services.AddTransient<LoginViewModel>();
    services.AddTransient<HomeViewModel>();
    services.AddTransient<NuevoExpedienteViewModel>();
    services.AddTransient<PacienteDetalleViewModel>();
    services.AddTransient<ConfiguracionViewModel>();
  }
}