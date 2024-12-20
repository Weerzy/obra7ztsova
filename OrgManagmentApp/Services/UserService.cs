using System.Security.Cryptography;
using System.Text;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using OrgManagmentApp.Db;
using OrgManagmentApp.Models;

namespace OrgManagmentApp.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _context;
        
    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User?> AuthenticateAsync(string login, string password)
    {
        var user = await GetUserByLoginAsync(login);
        if (user is null)
        {
            return null;
        }
        return BCrypt.Net.BCrypt.Verify(password, user.PasswordHash) ? user : null;
    }

    public string ComputeHash(string input)
    {
        return BCrypt.Net.BCrypt.HashPassword(input);
    }
    
    public async Task CreateUserAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }
    
    public async Task<User> GetUserByLoginAsync(string login)
    {
        return await _context.Users
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.Login == login);
    }
    
    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _context.Users.Include(u => u.Role).ToListAsync();
    }

    public async Task DeleteUserAsync(int userId)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user != null && user.RoleID != 1) // Не позволяем удалять администратора
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}