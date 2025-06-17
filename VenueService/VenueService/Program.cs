using Domain.Context;
using Microsoft.EntityFrameworkCore;
using Services.ExternalService;
using Services.VenueServices;
using VenueRepositoryLayer.Repository;

var builder = WebApplication.CreateBuilder(args);
// Db Connection
builder.Services.AddDbContext<VenueContext>(option => { option.UseSqlServer(builder.Configuration.GetConnectionString("DbConn")); });
// Add services to the container.
builder.Services.AddScoped<IVenuesService, VenuesService>();
builder.Services.AddHttpClient<IService, Service>();
builder.Services.AddTransient<IVenueRepository, VenueRepository>();
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
