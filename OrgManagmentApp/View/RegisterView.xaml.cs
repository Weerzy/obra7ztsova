using System.Windows;
using OrgManagmentApp.ViewModel;

namespace OrgManagmentApp.View;

public partial class RegisterView : Window
{
    public RegisterView(RegisterViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}