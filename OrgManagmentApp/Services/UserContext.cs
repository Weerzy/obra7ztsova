using OrgManagmentApp.Models;

namespace OrgManagmentApp.Services;

public class UserContext : IUserContext
{
    public User CurrentUser { get; set; }
}