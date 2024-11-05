using Sofomo.Commands.Shared;
using Sofomo.Models.Dtos;

namespace Sofomo.Commands
{
    public record UpdateWeatherCommand(WeatherDto Weather, LocationDto Location) : ICommand;
}
