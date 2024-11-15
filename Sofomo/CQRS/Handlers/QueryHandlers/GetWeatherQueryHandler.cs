using MediatR;
using Sofomo.CQRS.Queries;
using Sofomo.CQRS.Repositories.Shared;
using Sofomo.Domain.Models.Dtos;

namespace Sofomo.CQRS.Handlers.QueryHandlers
{
    public class GetWeatherQueryHandler(IUnitOfWork UnitOfWork) : IRequestHandler<GetWeatherQuery, WeatherDto?>
    {
        public async Task<WeatherDto?> Handle(GetWeatherQuery request, CancellationToken cancellationToken)
        {
            return await UnitOfWork.WeatherRepository.GetByCoordinatesAsync(request.Latitude, request.Longitude);
        }
    }
}
