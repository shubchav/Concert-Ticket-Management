using EventServiceDomain.Models;

namespace Services.Services
{
    public interface IEventsService
    {
        Task<EventDetail> CreateEvent(EventDetail eventDetail);
        Task<EventDetail> GetEventDetailsByName(string eventName);
        Task<EventDetail> UpdateEvent(EventDetail eventDetail);
        Task<List<EventDetail>> GetEventDetailsByVenueId(int venueId);
    }
}