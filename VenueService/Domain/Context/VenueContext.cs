using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Domain.Context
{
    public class VenueContext : DbContext
    {
        private readonly IConfiguration IConfiguration;
        public VenueContext(DbContextOptions<VenueContext> options, IConfiguration configuration)
        {
            IConfiguration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);


            optionsBuilder.UseSqlServer(IConfiguration.GetConnectionString("DbConn"));

        }
        public DbSet<Venues> Venues { get; set; }

    }
}


