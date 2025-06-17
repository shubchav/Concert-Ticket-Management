using TicketDomain.Model;

namespace TicketServicesLayer.Services
{
    public interface ITicketsService
    {
        Task<ResponseModel> CreateTicket(TicketManager ticket);
        Task<List<TicketTypes>> GetTicketTypes();
        Task<List<TicketManager>> GetTicketByEventId(int eventId);
        Task<ResponseModel> CancellRservedTickect(int ticketId);
    }
}