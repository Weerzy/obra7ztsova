using Microsoft.EntityFrameworkCore;
using OrgManagmentApp.Db;
using OrgManagmentApp.Models;

namespace OrgManagmentApp.Services;

public class OrganizerService : IOrganizerService
{
    private readonly AppDbContext _context;

    public OrganizerService(AppDbContext context)
    {
        _context = context;
    }

    public List<Organizer> GetAllOrganizersAsync()
    {
        return _context.Organizers.Include(o => o.Organization).ToList();
    }
}