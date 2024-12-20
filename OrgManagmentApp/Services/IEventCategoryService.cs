using OrgManagmentApp.Models;

namespace OrgManagmentApp.Services;

public interface IEventCategoryService
{
    List<EventCategory> GetAllCategoriesAsync();
    Task DeleteCategoryAsync(EventCategory category);
    Task UpdateCategoryAsync(EventCategory category);
    Task GetCategoryById(int id);
    public Task AddCategoryAsync(EventCategory category);
}