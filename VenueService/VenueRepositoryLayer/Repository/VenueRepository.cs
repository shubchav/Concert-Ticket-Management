using Domain.Context;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenueRepositoryLayer.Repository
{
    public class VenueRepository : IVenueRepository
    {
        private readonly VenueContext _venueContext;
        public VenueRepository(VenueContext venueContext)
        {
            _venueContext = venueContext;
        }

        // post
        public async Task<Venues> CreateVenue(Venues venue)
        {
            _venueContext.Venues.Add(venue);
            await _venueContext.SaveChangesAsync();
            return venue;
        }

        public async Task<Venues> GetVenueByVenueId(int venueId)
        {
            var venue = _venueContext.Venues.Where(a => a.VenueId == venueId).FirstOrDefault();

            return venue;
        }

    }
}
