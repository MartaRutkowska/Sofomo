using Microsoft.EntityFrameworkCore;
using Sofomo.Models.Dtos;
using Sofomo.Models.Request;

namespace Sofomo.Repositories
{
    public class WeatherRepository(DatabaseContext _context) : IWeatherRepository
    {
        public async Task AddAsync(WeatherDto weather)
        {
            await _context.Weather.AddAsync(weather);
        }

        public async Task<WeatherDto?> GetAsync(double latitude, double longtitude)
        {
            return await _context.Weather.SingleOrDefaultAsync(x => x.Location.Longitude == longtitude && x.Location.Latitude == latitude);
        }

        public async Task Update(WeatherDto weather, LocationDto location)
        {
            var scope = await _context.Locations.SingleAsync(x => x.Id == location.Id);

            var existingWeather = await _context.Weather.SingleOrDefaultAsync(x => x.LocationDtoId == scope.Id);
            if (existingWeather != null)
            {
                _context.Weather.Remove(existingWeather);
            }

            scope.Weather = weather;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
