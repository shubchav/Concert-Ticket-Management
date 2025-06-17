using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class VenueWithEventVM
    {
        public Venues Venue { get; set; }
        public List<EventDetail> EventDetails { get; set; }
    }
}
