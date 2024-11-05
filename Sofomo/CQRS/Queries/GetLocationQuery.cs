using Sofomo.CQRS.Queries.Shared;
using Sofomo.Domain.Models.Dtos;

namespace Sofomo.CQRS.Queries
{
    public record GetLocationQuery(double Latitude, double Longitude) : IQuery<LocationDto>;

}
