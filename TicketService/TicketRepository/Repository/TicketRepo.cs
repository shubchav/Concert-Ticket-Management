using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketDomain.Context;
using TicketDomain.Model;

namespace TicketRepository.Repository
{
    public class TicketRepo : ITicketRepo
    {
        private readonly TicketContext _ticketContext;
        public TicketRepo(TicketContext ticketContext)
        {
            _ticketContext = ticketContext;
        }

        // post
        public async Task<TicketManager> CreateTicket(TicketManager ticket)
        {
            _ticketContext.TicketManager.Add(ticket);
            await _ticketContext.SaveChangesAsync();
            return ticket;
        }
        
        public async Task<TicketManager> UpdateTicket(TicketManager ticket)
        {
            _ticketContext.TicketManager.Update(ticket);
            await _ticketContext.SaveChangesAsync();
            return ticket;
        }
        //// Get TicketTypes
        public async Task<List<TicketTypes>> GetTicketTypes()
        {
            var ticketTypes = await _ticketContext.TicketTypes.ToListAsync();

            return ticketTypes;
        }
        public async Task<List<TicketManager>> GetTickets()
        {
            var tickets = await _ticketContext.TicketManager.ToListAsync();

            return tickets;
        }

        public async Task<List<TicketManager>> GetTicketByEventId(int eventId)
        {
            var tickets = await _ticketContext.TicketManager.Where(t=>t.EventId == eventId).ToListAsync();

            return tickets;
        }

        public async Task<TicketManager> GetTicketByTicketId(int ticketID)
        {
            var ticket = await _ticketContext.TicketManager.Where(t => t.TicketId == ticketID).FirstOrDefaultAsync();

            return ticket;
        }



    }
}
