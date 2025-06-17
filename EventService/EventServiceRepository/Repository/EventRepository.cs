using EventServiceDomain.Context;
using EventServiceDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventServiceRepository.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly EventContext _eventContext;
        public EventRepository(EventContext eventContext)
        {
            _eventContext = eventContext;
        }

        // post
        public async Task<EventDetail> CreateEvent(EventDetail eventDetail)
        {
            _eventContext.EventDetail.Add(eventDetail);
            await _eventContext.SaveChangesAsync();
            return eventDetail;
        }
        // Get by event name

        public async Task<EventDetail> GetEventDetailsByName(string eventName)
        {
            var eventDetail = _eventContext.EventDetail.Where(a => a.Name.ToLower() == eventName.ToLower()).FirstOrDefault();

            return eventDetail;
        }

        //put
        public async Task<EventDetail> UpdateEvent(EventDetail eventDetail)
        {
            _eventContext.EventDetail.Update(eventDetail);
            await _eventContext.SaveChangesAsync();
            return eventDetail;
        }

        public async Task<List<EventDetail>> GetEventDetailsByVenueId(int venueId)
        {
            var eventDetails = _eventContext.EventDetail.Where(a => a.VenueId == venueId).ToList();

            return eventDetails;
        }

    }
}
