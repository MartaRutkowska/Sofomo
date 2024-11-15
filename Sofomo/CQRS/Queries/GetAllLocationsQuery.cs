using MediatR;
using Sofomo.Domain.Models.Dtos;

namespace Sofomo.CQRS.Queries
{
    public record GetAllLocationsQuery() : IRequest<IEnumerable<LocationDto>>;
}
