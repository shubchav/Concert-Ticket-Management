using Domain.Models;

namespace Services.ExternalService
{
    public interface IService
    {
        Task<List<EventDetail>?> GetEventDetailByVenueId(int venueId);
    }
}