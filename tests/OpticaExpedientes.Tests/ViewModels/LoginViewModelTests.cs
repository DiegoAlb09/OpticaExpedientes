using OpticaExpedientes.ViewModels;

namespace OpticaExpedientes.Tests.ViewModels;

public class LoginViewModelTests
{
  [Fact]
  public void UserName_IsOptica()
  {
    Assert.Equal("Optica", new LoginViewModel().UserName);
  }

  [Fact]
  public void SignIn_CannotExecute_WhenPasswordIsEmpty()
  {
    var vm = new LoginViewModel();

    Assert.False(vm.SignInCommand.CanExecute(null));
  }

  [Fact]
  public void SignIn_CanExecute_WhenPasswordHasValue()
  {
    var vm = new LoginViewModel { Password = "x" };

    Assert.True(vm.SignInCommand.CanExecute(null));
  }

  [Fact]
  public void SignIn_RaisesSignedIn()
  {
    var vm = new LoginViewModel { Password = "x" };
    var raised = false;
    vm.SignedIn += (_, _) => raised = true;

    vm.SignInCommand.Execute(null);

    Assert.True(raised);
  }
}
