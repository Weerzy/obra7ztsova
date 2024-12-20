using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OrgManagmentApp.Models;
using OrgManagmentApp.Services;

namespace OrgManagmentApp.ViewModel;

public partial class TicketViewModel : BaseViewModel
{
    private readonly ITicketService _ticketService;
    private readonly IEventService _eventService;
    private readonly ILevelService _levelService;
    private readonly IUserContext _userContext;
    private readonly IEventTicketLevelService _eventTicketLevel;

    [ObservableProperty]
    private Event selectedEvent;

    [ObservableProperty]
    private EventTicketLevel selectedLevel;

    public ObservableCollection<Event> Events { get; }
    public ObservableCollection<EventTicketLevel> Levels { get; }

    public TicketViewModel(ITicketService ticketService, IEventService eventService, ILevelService levelService, IUserContext userContext, IEventTicketLevelService eventTicketLevel)
    {
        _ticketService = ticketService;
        _eventService = eventService;
        _levelService = levelService;
        _userContext = userContext;
        _eventTicketLevel = eventTicketLevel;

        Events = new ObservableCollection<Event>();
        Levels = new ObservableCollection<EventTicketLevel>();
    }

    partial void OnSelectedEventChanged(Event value)
    {
        LoadData();
    }

    private void LoadData()
    {
        var events = _eventService.GetAllEventsAsync();
        foreach (var ev in events)
            Events.Add(ev);

        var levels = _eventTicketLevel.GetTicketLevelsForEvent(selectedEvent.ID);
        foreach (var level in levels)
            Levels.Add(level);
    }

    [RelayCommand]
    private async void Register()
    {
        if (SelectedEvent == null || SelectedLevel == null)
        {
            // Уведомить пользователя о необходимости выбора
            return;
        }

        var ticket = new Ticket
        {
            EventID = SelectedEvent.ID,
            ParticipantID = _userContext.CurrentUser.ID, // Предполагается, что есть текущий пользователь
            LevelID = SelectedLevel.ID,
            Cost = SelectedLevel.Price
        };

        await _ticketService.CreateTicketAsync(ticket);
        MessageBox.Show("Вы успешно зарегистрировались на мероприятие!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
    }
}