using OrgManagmentApp.Db;
using OrgManagmentApp.Models;

namespace OrgManagmentApp.Services;

public class EventAddressService : IEventAddressService
{
    private readonly AppDbContext _context;

    public EventAddressService(AppDbContext context)
    {
        _context = context;
    }
    
    public List<EventAddress> GetAllEventAddresses()
    {
        return _context.EventAddresses.ToList();
    }
}