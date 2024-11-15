using MediatR;
using Sofomo.CQRS.Queries;
using Sofomo.CQRS.Repositories.Shared;
using Sofomo.Domain.Models.Dtos;

namespace Sofomo.CQRS.Handlers.QueryHandlers
{
    public class GetAllLocationsQueryHandler(IUnitOfWork UnitOfWork) : IRequestHandler<GetAllLocationsQuery, IEnumerable<LocationDto?>>
    {

        public async Task<IEnumerable<LocationDto?>> Handle(GetAllLocationsQuery request, CancellationToken cancellationToken)
        {
            return await UnitOfWork.LocationRepository.GetAllAsync();
        }
    }
}
