using System.Windows.Controls;
using OpticaExpedientes.ViewModels;

namespace OpticaExpedientes.Views.Pages;

public partial class PacienteDetallePage : Page
{
  public PacienteDetallePage(PacienteDetalleViewModel viewModel)
  {
    DataContext = viewModel;
    InitializeComponent();
  }
}
