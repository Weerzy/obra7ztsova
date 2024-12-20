using OrgManagmentApp.Models;

namespace OrgManagmentApp.Services;

public interface IEventAddressService
{
    public List<EventAddress> GetAllEventAddresses();
}