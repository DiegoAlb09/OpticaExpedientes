using OpticaExpedientes.Views.Pages;
using Wpf.Ui.Abstractions;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;

namespace OpticaExpedientes.Views;

public partial class ShellWindow : FluentWindow
{
  public ShellWindow(INavigationViewPageProvider pageProvider)
  {
    SystemThemeWatcher.Watch(this);
    InitializeComponent();

    RootNavigation.SetPageProviderService(pageProvider);
    Loaded += (_, _) => RootNavigation.Navigate(typeof(HomePage));
  }
}