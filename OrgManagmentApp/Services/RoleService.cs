using Microsoft.EntityFrameworkCore;
using OrgManagmentApp.Db;
using OrgManagmentApp.Models;

namespace OrgManagmentApp.Services;

public class RoleService : IRoleService
{
    private readonly AppDbContext _context;

    public RoleService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Role>> GetAllRolesAsync()
    {
        return await _context.Roles.ToListAsync();
    }
}