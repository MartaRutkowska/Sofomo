using Sofomo.Models.Dtos;
using Sofomo.Queries;
using Sofomo.Queries.Shared;
using Sofomo.Repositories;

namespace Sofomo.Handlers.QueryHandlers
{
    public class GetLocationQueryHandler(ILocationRepository _locationRepository)
    {
        public async Task<LocationDto?> HandleAsync(GetLocationQuery query)
        {
            return await _locationRepository.GetAsync(query.Latitude, query.Longitude);
        }
    }
}
