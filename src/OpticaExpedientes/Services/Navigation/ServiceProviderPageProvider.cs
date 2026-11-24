using Wpf.Ui.Abstractions;

namespace OpticaExpedientes.Services.Navigation;

// Resuelve las paginas del NavigationView desde el contenedor de inyeccion de dependencias.

public sealed class ServiceProviderPageProvider(IServiceProvider serviceProvider): INavigationViewPageProvider
{
  public object? GetPage(Type pageType) => serviceProvider.GetService(pageType);
}