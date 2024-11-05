using Sofomo.Commands.Shared;

namespace Sofomo.Commands
{
    public record DeleteCoordinatesCommand(double Latitude, double Longtitude) : ICommand;
}
