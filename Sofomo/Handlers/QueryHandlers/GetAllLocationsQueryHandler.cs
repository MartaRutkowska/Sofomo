using Sofomo.Models.Dtos;
using Sofomo.Queries;
using Sofomo.Repositories;

namespace Sofomo.Handlers.QueryHandlers
{
    public class GetAllLocationsQueryHandler(ILocationRepository _locationRepository)
    {
        public async Task<IEnumerable<LocationDto?>> HandleAsync(GetAllLocationsQuery query)
        {
            return await _locationRepository.GetAllAsync();
        }
    }
}
