using Sofomo.Models.Dtos;

namespace Sofomo.Repositories
{
    public interface ILocationRepository : IRepository
    {
        Task AddAsync(double latitude, double longtitude);
        Task<LocationDto?> GetAsync(double latitude, double longtitude);
        Task<IEnumerable<LocationDto?>> GetAllAsync();
        Task DeleteAsync(double latitude, double longtitude);
    }
}
