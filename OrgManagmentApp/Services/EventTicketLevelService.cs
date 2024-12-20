using Microsoft.EntityFrameworkCore;
using OrgManagmentApp.Db;
using OrgManagmentApp.Models;

namespace OrgManagmentApp.Services;

public class EventTicketLevelService : IEventTicketLevelService
{
    private readonly AppDbContext _context;

    public EventTicketLevelService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<EventTicketLevel>> GetTicketLevelsForEventAsync(int eventId)
    {
        return await _context.EventTicketLevels
            .Include(etl => etl.Level)
            .Where(etl => etl.EventID == eventId)
            .ToListAsync();
    }
    
    public List<EventTicketLevel> GetTicketLevelsForEvent(int eventId)
    {
        return _context.EventTicketLevels
            .Include(etl => etl.Level)
            .Where(etl => etl.EventID == eventId)
            .ToList();
    }

    public async Task<List<Level>> GetAvailableLevelsAsync()
    {
        return await _context.Levels.ToListAsync();
    }

    public async Task AddTicketLevelToEventAsync(EventTicketLevel ticketLevel)
    {
        _context.EventTicketLevels.Add(ticketLevel);
        await _context.SaveChangesAsync();
    }

    public Task DeleteAllTicketLevelsForEventAsync(int id)
    {
        var TicketLevels = _context.EventTicketLevels.Where(level => level.EventID == id).ToList();
        _context.EventTicketLevels.RemoveRange(TicketLevels);
        return Task.CompletedTask;
    }

    public async Task UpdateTicketLevelAsync(EventTicketLevel ticketLevel)
    {
        _context.EventTicketLevels.Update(ticketLevel);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTicketLevelAsync(int eventId, int levelId)
    {
        var ticketLevel = await _context.EventTicketLevels
            .FirstOrDefaultAsync(etl => etl.EventID == eventId && etl.LevelID == levelId);
            
        if (ticketLevel != null)
        {
            _context.EventTicketLevels.Remove(ticketLevel);
            await _context.SaveChangesAsync();
        }
    }
}