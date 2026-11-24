using System.Windows.Controls;
using OpticaExpedientes.ViewModels;

namespace OpticaExpedientes.Views.Pages;

public partial class HomePage : Page
{
  public HomePage(HomeViewModel viewModel)
  {
    DataContext = viewModel;
    InitializeComponent();
  }
}