using OrgManagmentApp.Models;

namespace OrgManagmentApp.Services;

public interface IUserService
{
    Task<User?> AuthenticateAsync(string login, string password);
    Task CreateUserAsync(User user);
    Task<User> GetUserByLoginAsync(string login);
    
    Task<List<User>> GetAllUsersAsync();
    Task DeleteUserAsync(int userId);
    string ComputeHash(string input); // Перенос метода в интерфейс
}