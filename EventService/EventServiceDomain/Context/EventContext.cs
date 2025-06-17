using EventServiceDomain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace EventServiceDomain.Context
{
    public class EventContext : DbContext
    {
        private readonly IConfiguration IConfiguration;
        public EventContext(DbContextOptions<EventContext> options, IConfiguration configuration)
        {
            IConfiguration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            
            optionsBuilder.UseSqlServer(IConfiguration.GetConnectionString("DbConn"));

        }
        public DbSet<EventDetail> EventDetail { get; set; }
    }

}


