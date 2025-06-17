using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketDomain.Context;
using TicketDomain.Model;
using TicketRepository.Repository;

namespace TicketServicesLayer.Services
{
    public class TicketsService : ITicketsService
    {
        private readonly ITicketRepo _ticketRepository;
        public TicketsService(ITicketRepo ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        // post
        public async Task<ResponseModel> CreateTicket(TicketManager ticket)
        {
            var ticketTypes = await  _ticketRepository.GetTicketTypes();
            int availableQuantity =  ticketTypes.Where(t=> t.Id == ticket.TicketTypeId).Select(t=> t.QuantityAvailable).FirstOrDefault();
            var tickets = await _ticketRepository.GetTickets();
            int acquiredQuantity = tickets.Where(t=>t.EventId == ticket.EventId && t.TicketTypeId == ticket.TicketTypeId && t.IsCancelled == false && t.IsPaymentDone == true && t.IsReserved == true).Count();
            ResponseModel response = new ResponseModel();
            
            if (availableQuantity <= acquiredQuantity)
            {
                response.StatusCode = 400;
                response.Response = null;
                response.Message = "Tickets not available for provided ticket type.";
                return response;
            }
            var data = await _ticketRepository.CreateTicket(ticket);
            response.StatusCode = 200;
            response.Message = "ticket details added.";
            response.Response = ticket;
            return response;
        }
        //// Get TicketTypes

        public async Task<List<TicketTypes>> GetTicketTypes()
        {
            var ticketTypes = await _ticketRepository.GetTicketTypes();

            return ticketTypes;
        }

        public async Task<List<TicketManager>> GetTicketByEventId(int eventId)
        {
            var tickets = await _ticketRepository.GetTicketByEventId(eventId);

            return tickets;
        }

        public async Task<ResponseModel> CancellRservedTickect(int ticketId)
        {
            ResponseModel response = new ResponseModel();
            var eventData = await _ticketRepository.GetTicketByTicketId(ticketId);
            if (eventData == null)
            {
                response.StatusCode = 404;
                response.Message = "Tickets not found.";
                response.Response = null;
                return response;
            }
            eventData.IsReserved = false;
            await _ticketRepository.UpdateTicket(eventData);
            response.StatusCode = 200;
            response.Message = "Sucessfull updated.";
            response.Response = eventData;
            return response;
        }

    }
}
