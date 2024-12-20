using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OrgManagmentApp.Models;
using OrgManagmentApp.Services;

namespace OrgManagmentApp.ViewModel;

public partial class AdminTicketsViewModel : ObservableObject
{
    private readonly ITicketService _ticketService;
    

    [ObservableProperty]
    private ObservableCollection<Ticket> tickets;
    
    [ObservableProperty]
    private Ticket? selectedTicket;

    public AdminTicketsViewModel(ITicketService ticketService)
    {
        _ticketService = ticketService;
        LoadTicketsAsync();
    }

    [RelayCommand]
    private async Task Delete()
    {
        if (SelectedTicket is null)
        {
            MessageBox.Show("Сначала выберите билет для удаления", "Внимание", MessageBoxButton.OK,
                MessageBoxImage.Information);
            return;
        }

        await _ticketService.DeleteTicketAsync(SelectedTicket);
        LoadTicketsAsync();
    }

    private async Task LoadTicketsAsync()
    {
        var tickets = await _ticketService.GetAllTicketsAsync();
        Tickets = new ObservableCollection<Ticket>(tickets);
    }
}