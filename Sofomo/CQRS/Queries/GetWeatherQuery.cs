using Sofomo.CQRS.Queries.Shared;
using Sofomo.Domain.Models.Dtos;

namespace Sofomo.CQRS.Queries
{
    public record GetWeatherQuery(double Latitude, double Longitude) : IQuery<WeatherDto>;
}
