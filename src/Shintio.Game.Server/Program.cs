using MagicOnion.Serialization;
using MagicOnion.Serialization.MemoryPack;
using Shintio.Game.Server.Services;

var builder = WebApplication.CreateBuilder(args);

MagicOnionSerializerProvider.Default = MemoryPackMagicOnionSerializerProvider.Instance;

// Add services to the container.
builder.Services.AddMagicOnion();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapMagicOnionService([typeof(HealthService)]);
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();