using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using OrgManagmentApp.ViewModel;

namespace OrgManagmentApp.View;

public partial class Categories : Window
{
    public Categories()
    {
        InitializeComponent();
        var vm = App.ServiceProvider.GetService<CategoriesViewModel>();
        DataContext = vm;
    }
}