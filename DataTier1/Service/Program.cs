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
<<<<<<< Updated upstream
=======
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowBlazorOrigin",
        builder =>
        {
            builder.WithOrigins("https://localhost:7185",
                "https://localhost:5200").AllowAnyHeader().AllowAnyMethod();

        });

});
>>>>>>> Stashed changes
var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<Service.Services.EventServiceImpl>();
<<<<<<< Updated upstream
=======
app.MapGrpcService<Service.Services.UserServiceImpl>();
app.MapGrpcService<Service.Services.PostServiceImpl>();
>>>>>>> Stashed changes
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
