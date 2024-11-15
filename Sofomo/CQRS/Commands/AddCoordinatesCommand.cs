using MediatR;

namespace Sofomo.CQRS.Commands
{
    public record AddCoordinatesCommand(double Latitude, double Longitude) : IRequest;
}
