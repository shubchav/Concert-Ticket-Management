using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Services.ExternalService
{
    public class Service : IService
    {
        private readonly HttpClient _httpClient;
        public Service(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<EventDetail>?> GetEventDetailByVenueId(int venueId)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5168/events/EventDetailsByVenueId/{venueId}");

            if (!response.IsSuccessStatusCode)
            {
                // Handle errors, log or throw if needed
                return null;
            }

            var json = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var wrapper = JsonSerializer.Deserialize<ResponseModel<List<EventDetail>>>(json, options);

            // Deserialize the Response field into a list of EventDetail
        
            return wrapper?.Response ?? new List<EventDetail>();
        }
    }
}
