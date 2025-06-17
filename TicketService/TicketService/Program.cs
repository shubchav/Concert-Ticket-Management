using Microsoft.EntityFrameworkCore;
using TicketDomain.Context;
using TicketRepository.Repository;
using TicketServicesLayer.Services;

var builder = WebApplication.CreateBuilder(args);
// Db Connection
builder.Services.AddDbContext<TicketContext>(option => { option.UseSqlServer(builder.Configuration.GetConnectionString("DbConn")); });
// Add services to the container.
builder.Services.AddScoped<ITicketsService, TicketsService>();
builder.Services.AddTransient<ITicketRepo, TicketRepo>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
