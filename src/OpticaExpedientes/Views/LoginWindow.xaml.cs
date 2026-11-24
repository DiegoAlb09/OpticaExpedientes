using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using OpticaExpedientes.ViewModels;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;

namespace OpticaExpedientes.Views;

public partial class LoginWindow : FluentWindow
{
  private readonly LoginViewModel _viewModel;

  public LoginWindow(LoginViewModel viewModel, IServiceProvider serviceProvider)
  {
    _viewModel = viewModel;
    DataContext = viewModel;

    SystemThemeWatcher.Watch(this);
    InitializeComponent();

    _viewModel.SignedIn += (_, _) =>
    {
      var shell = serviceProvider.GetRequiredService<ShellWindow>();
      shell.Show();
      Close();
    };
  }

  // PasswordBox.Password no es enlazable; se pasa al ViewModel desde aquí.
  private void OnPasswordChanged(object sender, RoutedEventArgs e) =>
      _viewModel.Password = PasswordInput.Password;
}