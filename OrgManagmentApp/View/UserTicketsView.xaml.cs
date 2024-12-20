using System.Windows;
using OrgManagmentApp.ViewModel;

namespace OrgManagmentApp.View;

public partial class UserTicketsView : Window
{
    public UserTicketsView(UserTicketsViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}