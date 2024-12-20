using OrgManagmentApp.Models;

namespace OrgManagmentApp.Services;

public interface IEventTicketLevelService
{
    Task<List<EventTicketLevel>> GetTicketLevelsForEventAsync(int eventId);
    Task<List<Level>> GetAvailableLevelsAsync();
    Task AddTicketLevelToEventAsync(EventTicketLevel ticketLevel);

    public List<EventTicketLevel> GetTicketLevelsForEvent(int eventId);

    Task DeleteAllTicketLevelsForEventAsync(int id);
    Task UpdateTicketLevelAsync(EventTicketLevel ticketLevel);
    Task DeleteTicketLevelAsync(int eventId, int levelId);
}