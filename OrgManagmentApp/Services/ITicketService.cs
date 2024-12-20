using System.Threading.Tasks;
using OrgManagmentApp.Models;

namespace OrgManagmentApp.Services
{
    public interface ITicketService
    {
        Task CreateTicketAsync(Ticket ticket);
        Task<List<Ticket>> GetAllTicketsAsync();
        Task<List<Ticket>> GetTicketsByUserAsync(int userId);

        Task DeleteTicketAsync(Ticket ticket);
    }
}