using MediatR;

namespace Sofomo.CQRS.Commands
{
    public record RemoveCoordinatesCommand(double Latitude, double Longtitude) : IRequest;
}
