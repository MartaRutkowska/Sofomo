using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Sofomo.Config;
using Sofomo.CQRS.Handlers;
using Sofomo.CQRS.Repositories;
using Sofomo.CQRS.Repositories.Shared;
using Sofomo.Services;
using Sofomo.Utils.Exceptions;
using Sofomo.Utils.Mappers;
using Swashbuckle.Swagger;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.Configure<ExternalServiceSettings>(builder.Configuration.GetSection("ExternalServiceSettings"));

builder.Services.AddDbContext<DatabaseContext>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddControllers();
builder.Services.AddScoped<IWeatherRepository, WeatherRepository>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddTransient<ExternalMeteoService>();
builder.Services.AddTransient<IForecastService, ForecastService>();
builder.Services.RegisterServices(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sofomo API", Version = "v1" });
    c.IncludeXmlComments(Path.Combine(System.AppContext.BaseDirectory, "Sofomo.xml"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
