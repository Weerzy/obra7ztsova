using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using OrgManagmentApp.Models;
using OrgManagmentApp.Services;
using OrgManagmentApp.View;

namespace OrgManagmentApp.ViewModel;

public partial class MainViewModel : BaseViewModel
{
    private readonly IEventService _eventService;
    private readonly IServiceProvider _serviceProvider;
    private readonly IUserContext _userContext;

    [ObservableProperty]
    private ObservableCollection<Event> events;

    [ObservableProperty]
    private Event selectedEvent;

    public MainViewModel(IEventService eventService, IServiceProvider serviceProvider, IUserContext userContext)
    { 
        _eventService = eventService; 
        _serviceProvider = serviceProvider;
        _userContext = userContext;
        LoadEventsAsync();
    }

    private void LoadEventsAsync()
    { 
        var events = _eventService.GetAllEventsAsync();
        Events = new ObservableCollection<Event>(events);
    }

    [RelayCommand]
    private void CreateEvent()
    { 
        var eventView = _serviceProvider.GetRequiredService<EventView>(); 
        eventView.ShowDialog();
        LoadEventsAsync();
    }

        [RelayCommand]
        private void EditEvent()
        {
            if (SelectedEvent != null)
            {
                var eventWindow = _serviceProvider.GetRequiredService<EventView>();
                var vm = eventWindow.DataContext as EventViewModel;
                vm.SetEvent(SelectedEvent);
                // Заполните остальные поля
                eventWindow.ShowDialog();
                LoadEventsAsync();
            }
        }
        
        [RelayCommand]
        private void ShowUserTickets()
        {
            var userTicketsView = _serviceProvider.GetRequiredService<UserTicketsView>();
            userTicketsView.ShowDialog();
        }

        [RelayCommand]
        private void OpenCategories()
        {
            var categoriesWindow = _serviceProvider.GetRequiredService<Categories>();
            categoriesWindow.ShowDialog();
        }

        [RelayCommand]
        private async Task DeleteEventAsync()
        {
            if (SelectedEvent != null)
            {
                var result = MessageBox.Show("Вы действительно хотите удалить выбранное мероприятие?", "Подтверждение", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    await _eventService.DeleteEventAsync(SelectedEvent.ID);
                    LoadEventsAsync();
                }
            }
        }
        
        [RelayCommand]
        private void OpenAdminPanel()
        {
            if (_userContext.CurrentUser.Role.Name == "Administrator")
            {
                var adminView = _serviceProvider.GetRequiredService<AdminView>();
                adminView.ShowDialog();
            }
            else
            {
                MessageBox.Show("У вас нет прав доступа к этой функции.", "Доступ запрещен", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        [RelayCommand]
        private void Exit()
        {
            var loginView = _serviceProvider.GetRequiredService<LoginView>();
            loginView.Show();
            Application.Current.Windows.OfType<MainView>().First().Close();
            _userContext.CurrentUser = null;
        }

        [RelayCommand]
        private void Tickets()
        {
            var ticketsWindow = _serviceProvider.GetRequiredService<AdminTicketsView>();
            ticketsWindow.ShowDialog();
        }
        
        [RelayCommand]
        private void RegisterForEvent()
        {
            if (SelectedEvent != null)
            {
                var ticketView = _serviceProvider.GetRequiredService<TicketView>();
                var ticketViewModel = _serviceProvider.GetRequiredService<TicketViewModel>();

                // Предустанавливаем выбранное мероприятие
                ticketViewModel.SelectedEvent = SelectedEvent;

                ticketView.DataContext = ticketViewModel;
                ticketView.ShowDialog();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите мероприятие для регистрации.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
}