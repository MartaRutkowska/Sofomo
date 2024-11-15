using MediatR;
using Sofomo.Domain.Models.Dtos;

namespace Sofomo.CQRS.Queries
{
    public record GetWeatherQuery(double Latitude, double Longitude) : IRequest<WeatherDto>;
}
