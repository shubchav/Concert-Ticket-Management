using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketDomain.Model
{
    public class TicketManager
    {
        public int TicketId {  get; set; }
        public int EventId { get; set; }
        public int TicketTypeId { get; set; }
        public bool IsPaymentDone { get; set; } = false;
        public bool IsReserved { get; set; } = false;
        public bool IsCancelled { get; set; } = false;
    }
}
