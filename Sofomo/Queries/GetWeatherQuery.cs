using Sofomo.Models.Dtos;
using Sofomo.Queries.Shared;

namespace Sofomo.Queries
{
    public record GetWeatherQuery(double Latitude, double Longitude) : IQuery<WeatherDto>;
}
