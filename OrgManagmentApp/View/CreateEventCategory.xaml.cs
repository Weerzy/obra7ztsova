using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using OrgManagmentApp.ViewModel;

namespace OrgManagmentApp.View;

public partial class CreateEventCategory : Window
{
    public CreateEventCategory()
    {
        InitializeComponent();
        var viewmodel = App.ServiceProvider.GetService<CreateCategoryViewModel>();
        DataContext = viewmodel;
    }
}