using Sofomo.CQRS.Repositories.Shared;
using Sofomo.Domain.Models.Dtos;

namespace Sofomo.CQRS.Repositories
{
    public interface ILocationRepository : IRepository<LocationDto>
    {
        Task<LocationDto?> GetByCoordinatesAsync(double Latitude, double Longitude);
    }
}
