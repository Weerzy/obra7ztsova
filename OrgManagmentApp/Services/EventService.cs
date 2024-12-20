using Microsoft.EntityFrameworkCore;
using OrgManagmentApp.Db;
using OrgManagmentApp.Models;

namespace OrgManagmentApp.Services;

public class EventService : IEventService
{
    private readonly AppDbContext _context;

    public EventService(AppDbContext context)
    {
        _context = context;
    }

    public List<Event> GetAllEventsAsync()
    {
        return _context.Events
            .Include(e => e.EventCategory)
            .Include(e => e.Organizer)
            .Include(e => e.EventAddress)
            .ToList();
    }

    public async Task<Event> GetEventByIdAsync(int id)
    {
        return _context.Events
            .Include(e => e.EventCategory)
            .Include(e => e.Organizer)
            .Include(e => e.EventAddress)
            .FirstOrDefault(e => e.ID == id);
    }

    public async Task<int> CreateEventAsync(Event eventEntity)
    {
        _context.Events.Add(eventEntity);
        await _context.SaveChangesAsync();
        var newItem = await _context.Events.FirstAsync(item => item.Name == eventEntity.Name);
        return newItem.ID;
    }

    public async Task UpdateEventAsync(Event eventEntity)
    {
        _context.Events.Update(eventEntity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteEventAsync(int id)
    {
        var eventEntity = await _context.Events.FindAsync(id);
        if (eventEntity != null)
        {
            _context.Events.Remove(eventEntity);
            await _context.SaveChangesAsync();
        }
    }
}