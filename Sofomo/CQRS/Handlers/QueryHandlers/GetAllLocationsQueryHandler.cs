using Sofomo.CQRS.Queries;
using Sofomo.CQRS.Repositories.Shared;
using Sofomo.Domain.Models.Dtos;

namespace Sofomo.CQRS.Handlers.QueryHandlers
{
    public class GetAllLocationsQueryHandler(IUnitOfWork UnitOfWork)
    {
        public async Task<IEnumerable<LocationDto?>> HandleAsync(GetAllLocationsQuery query)
        {
            return await UnitOfWork.LocationRepository.GetAllAsync();
        }
    }
}
