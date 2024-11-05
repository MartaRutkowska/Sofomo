using Sofomo.Models.Dtos;
using Sofomo.Models.Response;
using Sofomo.Queries;
using Sofomo.Queries.Shared;
using Sofomo.Repositories;

namespace Sofomo.Handlers.QueryHandlers
{
    public class GetWeatherQueryHandler(IWeatherRepository _weatherRepository)
    {
        public async Task<WeatherDto?> HandleAsync(GetWeatherQuery query)
        {
            return await _weatherRepository.GetAsync(query.Latitude, query.Longitude);
        }
    }
}
