using Sofomo.CQRS.Queries;
using Sofomo.CQRS.Repositories.Shared;
using Sofomo.Domain.Models.Dtos;

namespace Sofomo.CQRS.Handlers.QueryHandlers
{
    public class GetWeatherQueryHandler(IUnitOfWork UnitOfWork)
    {
        public async Task<WeatherDto?> HandleAsync(GetWeatherQuery query)
        {
            return await UnitOfWork.WeatherRepository.GetByCoordinatesAsync(query.Latitude, query.Longitude);
        }
    }
}
