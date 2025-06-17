using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using TicketDomain.Model;

namespace TicketDomain.Context
{
    public class TicketContext : DbContext
    {
        private readonly IConfiguration IConfiguration;
        public TicketContext(DbContextOptions<TicketContext> options, IConfiguration configuration)
        {
            IConfiguration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);


            optionsBuilder.UseSqlServer(IConfiguration.GetConnectionString("DbConn"));

        }
        public DbSet<TicketTypes> TicketTypes { get; set; }
        public DbSet<TicketManager> TicketManager { get; set; }
    }
}


