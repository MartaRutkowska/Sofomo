using Sofomo.Domain.Models.Dtos;

namespace Sofomo.CQRS.Repositories
{
    public interface IWeatherRepository : IRepository
    {
        public Task AddAsync(WeatherDto weather);

        public Task Update(WeatherDto weather, LocationDto location);

        public Task<WeatherDto?> GetAsync(double latitude, double longtitude);
    }
}
