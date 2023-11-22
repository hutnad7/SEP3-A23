using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

using Service.Services;
using Data;
using Data.Interfaces;
using Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddDbContext<DBContext>(options =>
  options.UseMySQL(builder.Configuration.GetConnectionString("Database")));
builder.Services.AddScoped<IEnterteinerRepository, EnterteinerRepository>();
builder.Services.AddScoped<ICafeOwnerRepository, CafeOwnerRepository>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<Service.Services.EventServiceImpl>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

 app.Run();
