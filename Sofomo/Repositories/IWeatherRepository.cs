using Sofomo.Models.Dtos;
using Sofomo.Models.Request;

namespace Sofomo.Repositories
{
    public interface IWeatherRepository : IRepository
    {
        public Task AddAsync(WeatherDto weather);

        public Task Update(WeatherDto weather, LocationDto location);

        public Task<WeatherDto?> GetAsync(double latitude, double longtitude);
    }
}
