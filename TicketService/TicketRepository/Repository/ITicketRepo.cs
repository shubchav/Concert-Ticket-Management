

using System.Threading.Tasks;
using TicketDomain.Model;

namespace TicketRepository.Repository
{
    public interface ITicketRepo
    {
        Task<TicketManager> CreateTicket(TicketManager ticket);
        Task<List<TicketTypes>> GetTicketTypes();
        Task<List<TicketManager>> GetTicketByEventId(int eventId);
        Task<List<TicketManager>> GetTickets();
        Task <TicketManager> GetTicketByTicketId(int ticketID);
        Task<TicketManager> UpdateTicket(TicketManager ticket);
    }
}