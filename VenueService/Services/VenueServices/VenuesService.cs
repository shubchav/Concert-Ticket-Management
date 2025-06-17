using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenueRepositoryLayer.Repository;

namespace Services.VenueServices
{
    public class VenuesService : IVenuesService
    {
        private readonly IVenueRepository _venueRepository;
        
        public VenuesService(IVenueRepository venueRepository)
        {
            _venueRepository = venueRepository;
        }

        public async Task<Venues> CreateVenue(Venues venue)
        {
            await _venueRepository.CreateVenue(venue);
            return venue;
        }
        public async Task<Venues> GetVenueByVenueId(int venueId)
        {
            var venue = await _venueRepository.GetVenueByVenueId(venueId);

            return venue;
        }
        //public async Task<VenueWithEventVM?> GetEventDetailByVenueId(int venueId)
        //{
        //    var venueWithEventVM = new VenueWithEventVM();
        //    venueWithEventVM.Venue = new Venue();
        //    venueWithEventVM.EventDetails = new List<EventDetail>(); 
        //    var venue = _venueRepository.GetVenueByVenueId(venueId);
        //    var eventsByVenueId = 
        //    if (venue != null)
        //    {

        //    }

        //}
    }
}
