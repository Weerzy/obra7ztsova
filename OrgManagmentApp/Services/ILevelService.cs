using OrgManagmentApp.Models;

namespace OrgManagmentApp.Services;

public interface ILevelService
{
    List<Level> GetAllLevelsAsync();
    Task<Level> GetLevelByIdAsync(int id);
    Task CreateLevelAsync(Level level);
    Task UpdateLevelAsync(Level level);
    Task DeleteLevelAsync(int id);
}