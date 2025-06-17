

using Domain.Models;

namespace VenueRepositoryLayer.Repository
{
    public interface IVenueRepository
    {
        Task<Venues> CreateVenue(Venues venue);
        Task<Venues> GetVenueByVenueId(int venueId);

    }
}