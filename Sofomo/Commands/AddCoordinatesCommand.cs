using Sofomo.Commands.Shared;

namespace Sofomo.Commands
{
    public record AddCoordinatesCommand(double Latitude, double Longtitude) : ICommand;
}
