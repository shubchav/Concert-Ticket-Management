using EventServiceDomain.Context;
using EventServiceRepository.Repository;
using Microsoft.EntityFrameworkCore;
using Services.Services;

var builder = WebApplication.CreateBuilder(args);
// Db Connection
builder.Services.AddDbContext<EventContext>(option => { option.UseSqlServer(builder.Configuration.GetConnectionString("DbConn")); });
// Add services to the container.
builder.Services.AddTransient<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventsService, EventsService>();
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
