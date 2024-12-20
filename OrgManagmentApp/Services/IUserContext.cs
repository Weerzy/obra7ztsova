using OrgManagmentApp.Models;

namespace OrgManagmentApp.Services;

public interface IUserContext
{
    User CurrentUser { get; set; }
}