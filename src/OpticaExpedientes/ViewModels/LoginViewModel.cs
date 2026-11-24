using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace OpticaExpedientes.ViewModels;

/// <summary>
/// ATENCIÓN: marcador de posición (Fase 0). Acepta cualquier contraseña no vacía.
/// La autenticación real se implementa en la Fase 2 (feature/security-auth).
/// </summary>
public sealed partial class LoginViewModel : ViewModelBase
{
  public string UserName => "Optica";

  [ObservableProperty]
  [NotifyCanExecuteChangedFor(nameof(SignInCommand))]
  private string _password = string.Empty;

  [ObservableProperty]
  private string? _errorMessage;

  public event EventHandler? SignedIn;

  [RelayCommand(CanExecute = nameof(CanSignIn))]
  private void SignIn()
  {
    ErrorMessage = null;
    SignedIn?.Invoke(this, EventArgs.Empty);
  }

  private bool CanSignIn() => !string.IsNullOrEmpty(Password);
}
