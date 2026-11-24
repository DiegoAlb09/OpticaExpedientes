using System.Windows.Controls;
using OpticaExpedientes.ViewModels;

namespace OpticaExpedientes.Views.Pages;

public partial class ConfiguracionPage : Page
{
  public ConfiguracionPage(ConfiguracionViewModel viewModel)
  {
    DataContext = viewModel;
    InitializeComponent();
  }
}
