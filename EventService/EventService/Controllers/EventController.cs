using Azure;
using EventServiceDomain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace EventService.Controllers
{
    [ApiController]
    [Route("events")]
    public class EventController : ControllerBase
    {
        private readonly IEventsService _eventService;
        public EventController(IEventsService eventService)
        {
            _eventService = eventService;
        }
        // GET: EventController
        [HttpGet("{EventName}")]
        public async Task<IActionResult> EventDetailsByName(string eventName)
        {
            EventServiceDomain.Models.ResponseModel response = new EventServiceDomain.Models.ResponseModel();
            if (String.IsNullOrEmpty(eventName)) {
                response.StatusCode = 400;
                response.Response = null;
                response.Message = "Bad Requesr";
                return BadRequest(response);
            }
            var eventData = await _eventService.GetEventDetailsByName(eventName);
            response.StatusCode = 200;
            response.Message = "Sucessfully.";
            response.Response = eventData;
            return Ok(response);
        }
        
        [HttpGet("EventDetailsByVenueId/{venueId}")]
        public async Task<IActionResult> EventDetailsByVenueId(int venueId)
        {
            EventServiceDomain.Models.ResponseModel response = new EventServiceDomain.Models.ResponseModel();
            if (venueId == 0) {
                response.StatusCode = 400;
                response.Response = null;
                response.Message = "Bad Requesr";
                return BadRequest(response);
            }
            var eventData = await _eventService.GetEventDetailsByVenueId(venueId);
            response.StatusCode = 200;
            response.Message = "Sucessfully.";
            response.Response = eventData;
            return Ok(response);
        }

        [HttpPost("AddEvent")]
        public async Task<IActionResult> CreateEvent(EventDetail eventDetail)
        {
            EventServiceDomain.Models.ResponseModel response = new EventServiceDomain.Models.ResponseModel();

            if (!ModelState.IsValid)
            {
                response.StatusCode = 400;
                response.Response = null;
                response.Message = "Bad Requesr";
                return BadRequest(response);

            }

            await _eventService.CreateEvent(eventDetail);
            response.StatusCode = 200;
            response.Message = "Event details added.";
            response.Response = eventDetail;
            return Ok(response);

        }

        [HttpPut("UpdateEvent")]
        public async Task<IActionResult> UpdateEvent(EventDetail eventDetail)
        {
            EventServiceDomain.Models.ResponseModel response = new EventServiceDomain.Models.ResponseModel();

            if (!ModelState.IsValid)
            {
                response.StatusCode = 400;
                response.Response = null;
                response.Message = "Bad Requesr";
                return BadRequest(response);

            }

            await _eventService.UpdateEvent(eventDetail);
            response.StatusCode = 200;
            response.Message = "Event details updated.";
            response.Response = eventDetail;
            return Ok(response);

        }



    }
}
