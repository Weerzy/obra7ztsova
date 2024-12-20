using OrgManagmentApp.Models;

namespace OrgManagmentApp.Services;

public interface IEventService
{
    List<Event> GetAllEventsAsync();
    Task<Event> GetEventByIdAsync(int id);
    Task<int> CreateEventAsync(Event eventEntity);
    Task UpdateEventAsync(Event eventEntity);
    Task DeleteEventAsync(int id);
}