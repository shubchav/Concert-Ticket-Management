var builder = WebApplication.CreateBuilder(args);

// ✅ DEBUG: Confirm that ReverseProxy config is being loaded
Console.WriteLine("ReverseProxy.Routes loaded: " + builder.Configuration.GetSection("ReverseProxy:Routes").Exists());
Console.WriteLine("ReverseProxy.Clusters loaded: " + builder.Configuration.GetSection("ReverseProxy:Clusters").Exists());

// Load YARP config
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

// ✅ CRUCIAL: Map the reverse proxy
app.MapReverseProxy();

app.Run();
