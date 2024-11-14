using MediatR;
using Sofomo.Domain.Models.Dtos;

namespace Sofomo.CQRS.Commands
{
    public record UpdateWeatherCommand(WeatherDto Weather, LocationDto Location) : IRequest;
}
