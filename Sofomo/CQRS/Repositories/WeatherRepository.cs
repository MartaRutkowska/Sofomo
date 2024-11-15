using Microsoft.EntityFrameworkCore;
using Sofomo.CQRS.Repositories.Shared;
using Sofomo.Domain.Models.Dtos;

namespace Sofomo.CQRS.Repositories
{
    public class WeatherRepository: Repository<WeatherDto>, IWeatherRepository
    {
        private DatabaseContext DatabaseContext => Context as DatabaseContext;

        public WeatherRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<WeatherDto?> GetByCoordinatesAsync(double latitude, double longtitude)
        {
            return await DatabaseContext.Weather.SingleOrDefaultAsync(x => x.Location.Longitude == longtitude && x.Location.Latitude == latitude);
        }

        public async Task UpdateForCoordinates(WeatherDto weather, int locationId)
        {
            var scope = await DatabaseContext.Locations.SingleAsync(x => x.Id == locationId);

            var existingWeather = await DatabaseContext.Weather.SingleOrDefaultAsync(x => x.LocationDtoId == scope.Id);
            if (existingWeather != null)
            {
                DatabaseContext.Weather.Remove(existingWeather);
            }

            scope.Weather = weather;
        }
    }
}
