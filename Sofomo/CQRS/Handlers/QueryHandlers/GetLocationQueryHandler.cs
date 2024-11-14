using Sofomo.CQRS.Queries;
using Sofomo.CQRS.Repositories.Shared;
using Sofomo.Domain.Models.Dtos;

namespace Sofomo.CQRS.Handlers.QueryHandlers
{
    public class GetLocationQueryHandler(IUnitOfWork UnitOfWork)
    {
        public async Task<LocationDto?> HandleAsync(GetLocationQuery query)
        {

            return await UnitOfWork.LocationRepository.GetByCoordinatesAsync(query.Latitude, query.Longitude);
        }
    }
}
