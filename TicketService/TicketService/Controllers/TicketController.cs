using Azure;
using Microsoft.AspNetCore.Mvc;
using TicketDomain.Model;
using TicketServicesLayer.Services;

namespace TicketService.Controllers
{
    [ApiController]
    [Route("tickets")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketsService _ticketsService;
        public TicketController(ITicketsService ticketsService)
        {
            _ticketsService = ticketsService;   
        }

        [HttpGet("TicketTypes")]
        public async Task<IActionResult> TicketTypes()
        {
            ResponseModel response = new ResponseModel();
            var ticketTypes = await _ticketsService.GetTicketTypes();
            if (ticketTypes == null || ticketTypes.Count == 0)
            {
                response.StatusCode = 404;
                response.Message = "Tickets type were not found.";
                response.Response = null;
                return NotFound(response);
            }
            response.StatusCode = 200;
            response.Message = "Sucessfull.";
            response.Response = ticketTypes;
            return Ok(response);
        }

        [HttpGet("{eventId}")]
        public async Task<IActionResult> TicketsByEventId(int eventId)
        {
            ResponseModel response = new ResponseModel();
            var tickets = await _ticketsService.GetTicketByEventId(eventId);
            if (tickets == null || tickets.Count == 0)
            {
                response.StatusCode = 404;
                response.Message = "Tickets not found.";
                response.Response = null;
                return NotFound(response);
            }
            response.StatusCode = 200;
            response.Message = "Sucessfull.";
            response.Response = tickets;
            return Ok(response);
        }

        [HttpPost("AddTickect")]
        public async Task<IActionResult> CreateEvent(TicketManager ticket)
        {
            ResponseModel response = new ResponseModel();

            if (!ModelState.IsValid)
            {
                response.StatusCode = 400;
                response.Response = null;
                response.Message = "Bad Requesr";
                return BadRequest(response);

            }

            var result = await _ticketsService.CreateTicket(ticket);
            response.StatusCode = 200;
            response.Message = "ticket details added.";
            response.Response = ticket;
            return Ok(response);

        }

        [HttpPost("CancellRservedTickect/{ticketId}")]
        public async Task<IActionResult> CancellRservedTickect(int ticketId)
        {
            ResponseModel response = new ResponseModel();

            if (ticketId == 0)
            {
                response.StatusCode = 400;
                response.Response = null;
                response.Message = "Bad Requesr";
                return BadRequest(response);

            }

            var result = await _ticketsService.CancellRservedTickect(ticketId);
            
            return Ok(result);

        }
    }
}
