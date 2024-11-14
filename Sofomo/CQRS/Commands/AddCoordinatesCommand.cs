using Sofomo.CQRS.Commands.Shared;

namespace Sofomo.CQRS.Commands
{
    public record AddCoordinatesCommand(double Latitude, double Longitude) : ICommand;
}
