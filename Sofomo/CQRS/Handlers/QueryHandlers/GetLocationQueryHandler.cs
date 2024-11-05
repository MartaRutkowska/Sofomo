using Sofomo.CQRS.Queries;
using Sofomo.CQRS.Repositories;
using Sofomo.Domain.Models.Dtos;

namespace Sofomo.CQRS.Handlers.QueryHandlers
{
    public class GetLocationQueryHandler(ILocationRepository _locationRepository)
    {
        public async Task<LocationDto?> HandleAsync(GetLocationQuery query)
        {
            return await _locationRepository.GetAsync(query.Latitude, query.Longitude);
        }
    }
}
