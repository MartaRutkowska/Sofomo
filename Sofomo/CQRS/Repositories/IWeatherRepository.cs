using Sofomo.Domain.Models.Dtos;

namespace Sofomo.CQRS.Repositories
{
    public interface IWeatherRepository : IRepository<WeatherDto>
    {
        public Task<WeatherDto?> GetByCoordinatesAsync(double latitude, double longtitude);

        public Task UpdateForCoordinates(WeatherDto weather, LocationDto location);

    }
}
