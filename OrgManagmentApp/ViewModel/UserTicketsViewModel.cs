using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OrgManagmentApp.Models;
using OrgManagmentApp.Services;

namespace OrgManagmentApp.ViewModel;

public partial class UserTicketsViewModel : ObservableObject
{
    private readonly ITicketService _ticketService;
    private readonly IUserContext _userContext;

    [ObservableProperty]
    private ObservableCollection<Ticket> tickets;

    [ObservableProperty] private Ticket? selectedTicket;

    public UserTicketsViewModel(ITicketService ticketService, IUserContext userContext)
    {
        _ticketService = ticketService;
        _userContext = userContext;

        LoadTicketsAsync();
    }

    private async Task LoadTicketsAsync()
    {
        var userTickets = await _ticketService.GetTicketsByUserAsync(_userContext.CurrentUser.ID);
        Tickets = new ObservableCollection<Ticket>(userTickets);
    }

    [RelayCommand]
    private void RemoveTicket()
    {
        if (SelectedTicket is null)
        {
            MessageBox.Show("Сначала выберите билет для удаления!", "Внимание", MessageBoxButton.OK,
                MessageBoxImage.Information);
            return;
        }
        _ticketService.DeleteTicketAsync(SelectedTicket);
        LoadTicketsAsync();
    }
}