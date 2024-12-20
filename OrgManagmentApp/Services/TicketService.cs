using Microsoft.EntityFrameworkCore;
using OrgManagmentApp.Db;
using OrgManagmentApp.Models;

namespace OrgManagmentApp.Services;

public class TicketService : ITicketService
{
    private readonly AppDbContext _context;

    public TicketService(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateTicketAsync(Ticket ticket)
    {
        _context.Tickets.Add(ticket);
        await _context.SaveChangesAsync();
    }
    
    public async Task<List<Ticket>> GetAllTicketsAsync()
    {
        return await _context.Tickets
            .Include(t => t.Event)
            .Include(t => t.Participant)
            .Include(t => t.Level)
            .ToListAsync();
    }

    public async Task<List<Ticket>> GetTicketsByUserAsync(int userId)
    {
        return await _context.Tickets.Where(ticket => ticket.ParticipantID == userId).ToListAsync();
    }

    public async Task DeleteTicketAsync(Ticket ticket)
    {
        _context.Tickets.Remove(ticket);
        await _context.SaveChangesAsync();
    }
}