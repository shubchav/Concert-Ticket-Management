using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Services.ExternalService;
using Services.VenueServices;

namespace VenueService.Controllers
{
    [ApiController]
    [Route("venues")]
    public class VenueController : ControllerBase
    {
        private readonly IVenuesService _venuesService;
        private readonly IService _service;

        public VenueController(IVenuesService venuesService,IService service)
        {
            _venuesService = venuesService;
            _service = service;
        }

        [HttpPost("AddVenue")]
        public async Task<IActionResult> CreateVenue(Venues venue)
        {
            ResponseModel<Venues> response = new ResponseModel<Venues> ();

            if (!ModelState.IsValid)
            {
                response.StatusCode = 400;
                response.Response = null;
                response.Message = "Bad Requesr";
                return BadRequest(response);

            }

            await _venuesService.CreateVenue(venue);
            response.StatusCode = 200;
            response.Message = "Venue details added.";
            response.Response = venue;
            return Ok(response);

        }

        [HttpGet("VenuesWithEventsByVenueId/{venueId}")]
        public async Task<IActionResult> VenuesWithEventDetailsByVenueId(int venueId)
        {
            ResponseModel<VenueWithEventVM> response = new ResponseModel<VenueWithEventVM>();

            if (venueId == 0)
            {
                response.StatusCode = 400;
                response.Response = null;
                response.Message = "Bad Requesr";
                return BadRequest(response);
            }

            var venueWithEventVM = new VenueWithEventVM();
            venueWithEventVM.Venue = new Venues();
            venueWithEventVM.EventDetails = new List<EventDetail>();
            var venue = await _venuesService.GetVenueByVenueId(venueId);
            var eventsByVenueId = await _service.GetEventDetailByVenueId(venueId);
            if (venue == null ||  eventsByVenueId == null)
            {
                response.StatusCode = 404;
                response.Message = "Venues not found.";
                response.Response = null;
                return NotFound(response);
            }
            venueWithEventVM.Venue = venue;
            venueWithEventVM.EventDetails = eventsByVenueId;

            response.StatusCode = 200;
            response.Message = "Sucessfully.";
            response.Response = venueWithEventVM;
            return Ok(response);
        }
    }
}
