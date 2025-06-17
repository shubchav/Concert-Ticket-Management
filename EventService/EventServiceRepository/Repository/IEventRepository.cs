using EventServiceDomain.Models;

namespace EventServiceRepository.Repository
{
    public interface IEventRepository
    {
        Task<EventDetail> CreateEvent(EventDetail eventDetail);
        Task<EventDetail> GetEventDetailsByName(string eventName);
        Task<EventDetail> UpdateEvent(EventDetail eventDetail);
        Task<List<EventDetail>> GetEventDetailsByVenueId(int venueId);


    }
}