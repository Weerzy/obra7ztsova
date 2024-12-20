using OrgManagmentApp.Models;

namespace OrgManagmentApp.Services;

public interface IOrganizerService
{
    List<Organizer> GetAllOrganizersAsync();
}