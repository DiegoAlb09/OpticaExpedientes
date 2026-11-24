using System.Windows.Controls;
using OpticaExpedientes.ViewModels;

namespace OpticaExpedientes.Views.Pages;

public partial class NuevoExpedientePage : Page
{
  public NuevoExpedientePage(NuevoExpedienteViewModel viewModel)
  {
    DataContext = viewModel;
    InitializeComponent();
  }
}