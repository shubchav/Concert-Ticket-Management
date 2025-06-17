﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Venues
    {
        [Key]
        public int VenueId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
    }
}
