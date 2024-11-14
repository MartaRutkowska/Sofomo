using MediatR;
using Sofomo.Domain.Models.Dtos;

namespace Sofomo.CQRS.Queries
{
    public record GetLocationQuery(double Latitude, double Longitude) : IRequest<LocationDto>;

}
