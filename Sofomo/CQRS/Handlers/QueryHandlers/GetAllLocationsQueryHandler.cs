using Sofomo.CQRS.Queries;
using Sofomo.CQRS.Repositories;
using Sofomo.Domain.Models.Dtos;

namespace Sofomo.CQRS.Handlers.QueryHandlers
{
    public class GetAllLocationsQueryHandler(ILocationRepository _locationRepository)
    {
        public async Task<IEnumerable<LocationDto?>> HandleAsync(GetAllLocationsQuery query)
        {
            return await _locationRepository.GetAllAsync();
        }
    }
}
