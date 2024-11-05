using Sofomo.Models.Dtos;
using Sofomo.Queries.Shared;

namespace Sofomo.Queries
{
    public record GetAllLocationsQuery() : IQuery<LocationDto>;
}
