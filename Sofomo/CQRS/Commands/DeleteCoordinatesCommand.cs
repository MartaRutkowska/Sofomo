using Sofomo.CQRS.Commands.Shared;

namespace Sofomo.CQRS.Commands
{
    public record DeleteCoordinatesCommand(double Latitude, double Longtitude) : ICommand;
}
