using Microsoft.EntityFrameworkCore;
using OrgManagmentApp.Db;
using OrgManagmentApp.Models;

namespace OrgManagmentApp.Services;

public class EventCategoryService : IEventCategoryService
{
    private readonly AppDbContext _context;

    public EventCategoryService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task UpdateCategoryAsync(EventCategory category)
    {
        _context.EventCategories.Update(category);
        await _context.SaveChangesAsync();
    }

    public Task GetCategoryById(int id)
    {
        throw new NotImplementedException();
    }

    public List<EventCategory> GetAllCategoriesAsync()
    {
        return _context.EventCategories.ToList();
    }
    
    public async Task AddCategoryAsync(EventCategory category)
    {
        _context.EventCategories.Add(category);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCategoryAsync(EventCategory category)
    {
        _context.EventCategories.Remove(category);
        await _context.SaveChangesAsync();
    }
}