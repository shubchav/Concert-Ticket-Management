using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventServiceDomain.Models
{
    public record ResponseModel
    {
        public int StatusCode { get;  set; }
        public string? Message { get; set; }
        public object? Response { get; set; }
        public string? Error { get; set; }
    }
}
