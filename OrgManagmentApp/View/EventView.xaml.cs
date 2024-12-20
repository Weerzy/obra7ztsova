using System.Windows;
using OrgManagmentApp.ViewModel;

namespace OrgManagmentApp.View;

public partial class EventView : Window
{
    public EventView(EventViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}