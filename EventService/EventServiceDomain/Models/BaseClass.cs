using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventServiceDomain.Models
{
    public class BaseClass
    {
        public DateTime? CreateDate { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
