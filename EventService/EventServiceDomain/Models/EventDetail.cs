using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventServiceDomain.Models
{
    public class EventDetail : BaseClass
    {
        public int EventDetailId { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public DateTime? EventStartDate { get; set; }
        public DateTime? EventEndDate { get; set; }
        public bool IsEventCancel { get; set; } = false;
        public int VenueId { get; set; }

    }
}
