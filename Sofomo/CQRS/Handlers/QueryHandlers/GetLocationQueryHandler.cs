using MediatR;
using Sofomo.CQRS.Queries;
using Sofomo.CQRS.Repositories.Shared;
using Sofomo.Domain.Models.Dtos;

namespace Sofomo.CQRS.Handlers.QueryHandlers
{
    public class GetLocationQueryHandler(IUnitOfWork UnitOfWork) : IRequestHandler<GetLocationQuery, LocationDto?>
    {
        public async Task<LocationDto?> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {
            return await UnitOfWork.LocationRepository.GetByCoordinatesAsync(request.Latitude, request.Longitude);
        }
    }
}
