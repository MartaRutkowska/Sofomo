using Sofomo.CQRS.Queries;
using Sofomo.CQRS.Repositories;
using Sofomo.Domain.Models.Dtos;

namespace Sofomo.CQRS.Handlers.QueryHandlers
{
    public class GetWeatherQueryHandler(IWeatherRepository _weatherRepository)
    {
        public async Task<WeatherDto?> HandleAsync(GetWeatherQuery query)
        {
            return await _weatherRepository.GetAsync(query.Latitude, query.Longitude);
        }
    }
}
