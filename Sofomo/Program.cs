using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sofomo.Config;
using Sofomo.Handlers;
using Sofomo.Handlers.CommandHandler;
using Sofomo.Handlers.CommandHandlers;
using Sofomo.Handlers.QueryHandlers;
using Sofomo.Mappers;
using Sofomo.Repositories;
using Sofomo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.Configure<ExternalServiceSettings>(builder.Configuration.GetSection("ExternalServiceSettings"));

builder.Services.AddDbContext<DatabaseContext>();

builder.Services.AddControllers();
builder.Services.AddScoped<IWeatherRepository, WeatherRepository>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();

builder.Services.AddTransient<ExternalMeteoService>();
builder.Services.AddTransient<ForecastService>();
builder.Services.RegisterServices(builder.Configuration);

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();