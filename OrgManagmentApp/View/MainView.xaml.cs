using System.Windows;
using OrgManagmentApp.ViewModel;

namespace OrgManagmentApp.View;

public partial class MainView : Window
{
    public MainView(MainViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}