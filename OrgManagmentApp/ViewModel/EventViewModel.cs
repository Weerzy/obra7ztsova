using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OrgManagmentApp.Models;
using OrgManagmentApp.Services;
using OrgManagmentApp.View;

namespace OrgManagmentApp.ViewModel;

public partial class EventViewModel : ObservableValidator
{
    private readonly IEventService _eventService;
        private readonly IEventCategoryService _eventCategoryService;
        private readonly IOrganizerService _organizerService;
        private readonly IEventAddressService _eventAddressService;
        private readonly IEventTicketLevelService _eventTicketLevelService;
        private readonly Dictionary<string, List<string>> _errors = new();

        [ObservableProperty] private string title;

        [ObservableProperty]
        [Required(ErrorMessage = "Название мероприятия обязательно")]
        private string name;

        [ObservableProperty]
        [Required(ErrorMessage = "Дата мероприятия обязательна")]
        private DateTime date;

        [ObservableProperty]
        [Required(ErrorMessage = "Категория мероприятия обязательна")]
        private EventCategory selectedCategory;

        [ObservableProperty]
        [Required(ErrorMessage = "Организатор мероприятия обязателен")]
        private Organizer selectedOrganizer;
        
        [ObservableProperty]
        [Required(ErrorMessage = "Организатор мероприятия обязателен")]
        private EventAddress selectedAddress;
        
        [ObservableProperty]
        private ObservableCollection<Level> availableLevels;

        [ObservableProperty]
        private ObservableCollection<EventTicketLevel> selectedTicketLevels;

        [ObservableProperty]
        private Level selectedLevel;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Range(0.01, double.MaxValue, ErrorMessage = "Цена должна быть больше 0")]
        private decimal ticketPrice;

        private Event? _editingEvent;

        public ObservableCollection<EventCategory> Categories { get; private set; }
        public ObservableCollection<Organizer> Organizers { get; private set; }
        public ObservableCollection<EventAddress> Addresses { get; private set; }
        

        public EventViewModel(IEventService eventService, IEventCategoryService eventCategoryService, IOrganizerService organizerService, IEventAddressService eventAddressService, IEventTicketLevelService eventTicketLevelService)
        {
            _eventService = eventService;
            _eventCategoryService = eventCategoryService;
            _organizerService = organizerService;
            _eventAddressService = eventAddressService;
            _eventTicketLevelService = eventTicketLevelService;
        
            SelectedTicketLevels = new ObservableCollection<EventTicketLevel>();
            AvailableLevels = new ObservableCollection<Level>();
            Title = "Добавление мероприятия";
            LoadData();
        }

        public void SetEvent(Event selectedEvent)
        {
            _editingEvent = selectedEvent;
            Name = _editingEvent.Name;
            Date = DateTime.SpecifyKind(_editingEvent.Date, DateTimeKind.Utc);
            SelectedCategory = Categories.First(category => category.ID == _editingEvent.EventCategoryID);
            SelectedOrganizer = Organizers.First(organizer => organizer.ID == _editingEvent.OrganizerID);
            SelectedAddress = Addresses.First(address => address.ID == _editingEvent.EventAddressID);
            Title = "Редактирование мероприятия";
        }

        private async void LoadData()
        {
            var categories = _eventCategoryService.GetAllCategoriesAsync();
            Categories = new ObservableCollection<EventCategory>(categories);

            var organizers = _organizerService.GetAllOrganizersAsync();
            Organizers = new ObservableCollection<Organizer>(organizers);
            var addresses = _eventAddressService.GetAllEventAddresses();
            Addresses = new ObservableCollection<EventAddress>(addresses);
            
            var levels = await _eventTicketLevelService.GetAvailableLevelsAsync();
            AvailableLevels = new ObservableCollection<Level>(levels);

            if (_editingEvent != null)
            {
                var eventLevels = await _eventTicketLevelService.GetTicketLevelsForEventAsync(_editingEvent.ID);
                SelectedTicketLevels = new ObservableCollection<EventTicketLevel>(eventLevels);
                UpdateAvailableLevels();
            }
        }
        
        private void UpdateAvailableLevels()
        {
            var usedLevelIds = SelectedTicketLevels.Select(tl => tl.LevelID).ToList();
            var availableLevelsList = AvailableLevels.Where(l => !usedLevelIds.Contains(l.ID)).ToList();
            AvailableLevels = new ObservableCollection<Level>(availableLevelsList);
        }
        
        [RelayCommand]
        private void AddTicketLevel()
        {
            if (SelectedLevel == null) return;

            ValidateAllProperties();
            if (HasErrors) return;

            var ticketLevel = new EventTicketLevel
            {
                Level = SelectedLevel,
                LevelID = SelectedLevel.ID,
                Price = TicketPrice,
            };

            SelectedTicketLevels.Add(ticketLevel);
            UpdateAvailableLevels();

            // Сброс полей
            SelectedLevel = null;
            TicketPrice = 0;
        }
        
        [RelayCommand]
        private void RemoveTicketLevel(EventTicketLevel ticketLevel)
        {
            SelectedTicketLevels.Remove(ticketLevel);
            AvailableLevels.Add(ticketLevel.Level);
        }


        [RelayCommand]
        private async Task SaveEvent()
        {
            if (HasErrors || !SelectedTicketLevels.Any())
            {
                MessageBox.Show("Необходимо добавить хотя бы один уровень билетов", "Ошибка", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (_editingEvent != null)
            {
                _editingEvent.Name = Name;
                _editingEvent.Date = DateTime.SpecifyKind(Date, DateTimeKind.Utc);
                _editingEvent.EventCategoryID = SelectedCategory.ID;
                _editingEvent.EventAddressID = SelectedAddress.ID;
                _editingEvent.OrganizerID = SelectedOrganizer.ID;
                await _eventTicketLevelService.DeleteAllTicketLevelsForEventAsync(_editingEvent.ID);
                foreach (var ticketLevel in SelectedTicketLevels)
                {
                    ticketLevel.EventID = _editingEvent.ID;
                    await _eventTicketLevelService.AddTicketLevelToEventAsync(ticketLevel);
                }
                await _eventService.UpdateEventAsync(_editingEvent);
                MessageBox.Show("Событие успешно отредактировано!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                Application.Current.Windows.OfType<EventView>().First().Close();
            }
            else
            {
                var newEvent = new Event
                {
                    Name = Name,
                    Date = DateTime.SpecifyKind(Date, DateTimeKind.Utc),
                    EventCategoryID = SelectedCategory.ID,
                    EventAddressID = SelectedAddress.ID,
                    OrganizerID = SelectedOrganizer.ID
                    // Дополнительные поля
                };
                // Сохраняем событие и получаем его ID
                var createdEvent = await _eventService.CreateEventAsync(newEvent);

                // Добавляем уровни билетов
                foreach (var ticketLevel in SelectedTicketLevels)
                {
                    ticketLevel.EventID = createdEvent;
                    await _eventTicketLevelService.AddTicketLevelToEventAsync(ticketLevel);
                }
                MessageBox.Show("Мероприятие успешно добавлено!", "Успешно", MessageBoxButton.OK,
                    MessageBoxImage.Information);
                Application.Current.Windows.OfType<EventView>().First().Close();
            }
        }
}