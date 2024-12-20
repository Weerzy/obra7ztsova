using System.Windows;
using OrgManagmentApp.ViewModel;

namespace OrgManagmentApp.View;

public partial class CreateUserView : Window
{
    public CreateUserView(CreateUserViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}