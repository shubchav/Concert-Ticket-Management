using Domain.Models;

namespace Services.VenueServices
{
    public interface IVenuesService
    {
        Task<Venues> CreateVenue(Venues venue);
        Task<Venues> GetVenueByVenueId(int venueId);
    }
}