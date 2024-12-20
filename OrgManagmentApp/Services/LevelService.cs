using Microsoft.EntityFrameworkCore;
using OrgManagmentApp.Db;
using OrgManagmentApp.Models;

namespace OrgManagmentApp.Services;

public class LevelService : ILevelService
{
    private readonly AppDbContext _context;

    public LevelService(AppDbContext context)
    {
        _context = context;
    }

    public List<Level> GetAllLevelsAsync()
    {
        return _context.Levels.ToList();
    }

    public async Task<Level> GetLevelByIdAsync(int id)
    {
        return await _context.Levels.FindAsync(id);
    }

    public async Task CreateLevelAsync(Level level)
    {
        _context.Levels.Add(level);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateLevelAsync(Level level)
    {
        _context.Levels.Update(level);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteLevelAsync(int id)
    {
        var level = await _context.Levels.FindAsync(id);
        if (level != null)
        {
            _context.Levels.Remove(level);
            await _context.SaveChangesAsync();
        }
    }
}