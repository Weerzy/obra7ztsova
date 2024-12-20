using OrgManagmentApp.Models;

namespace OrgManagmentApp.Services;

public interface IRoleService
{
    Task<List<Role>> GetAllRolesAsync();
}