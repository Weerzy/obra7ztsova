using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using OrgManagmentApp.ViewModel;

namespace OrgManagmentApp.View;

public partial class AdminTicketsView : Window
{
    public AdminTicketsView(AdminTicketsViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}