using Microsoft.EntityFrameworkCore;
using Sofomo.CQRS.Repositories.Shared;
using Sofomo.Domain.Models.Dtos;

namespace Sofomo.CQRS.Repositories
{
    public class LocationRepository : Repository<LocationDto>, ILocationRepository
    {
        private DatabaseContext DatabaseContext => Context as DatabaseContext;

        public LocationRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<LocationDto?> GetByCoordinatesAsync(double Latitude, double Longitude)
        {
            return await DatabaseContext.Locations.SingleOrDefaultAsync(loc => loc.Latitude == Latitude && loc.Longitude == Longitude);
        }
    }
}
