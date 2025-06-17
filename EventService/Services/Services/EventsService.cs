using EventServiceDomain.Context;
using EventServiceDomain.Models;
using EventServiceRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class EventsService : IEventsService
    {
        private readonly IEventRepository _eventRepository;
        public EventsService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        // post
        public async Task<EventDetail> CreateEvent(EventDetail eventDetail)
        {
            await _eventRepository.CreateEvent(eventDetail);
            return eventDetail;
        }
        // Get by event name

        public async Task<EventDetail> GetEventDetailsByName(string eventName)
        {
            var eventDetail = await _eventRepository.GetEventDetailsByName(eventName);
            return eventDetail;
        }
        public async Task<EventDetail> UpdateEvent(EventDetail eventDetail)
        {
            await _eventRepository.UpdateEvent(eventDetail);
            return eventDetail;
        }

        public async Task<List<EventDetail>> GetEventDetailsByVenueId(int venueId)
        {
            var eventDetails = await _eventRepository.GetEventDetailsByVenueId(venueId);

            return eventDetails;
        }
    }
}
