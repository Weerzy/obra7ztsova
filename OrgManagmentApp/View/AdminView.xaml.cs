using System.Windows;
using OrgManagmentApp.ViewModel;

namespace OrgManagmentApp.View;

public partial class AdminView : Window
{
    public AdminView(AdminViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}