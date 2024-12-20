using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using OrgManagmentApp.ViewModel;

namespace OrgManagmentApp.View;

public partial class LoginView : Window
{
    public LoginView()
    {
        InitializeComponent();
        var loginViewModel = App.ServiceProvider.GetRequiredService<LoginViewModel>();
        DataContext = loginViewModel;
    }
}