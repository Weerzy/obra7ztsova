using System.Windows;
using OrgManagmentApp.ViewModel;

namespace OrgManagmentApp.View;

public partial class TicketView : Window
{
    public TicketView(TicketViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}