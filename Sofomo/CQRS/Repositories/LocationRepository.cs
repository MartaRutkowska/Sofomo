using Microsoft.EntityFrameworkCore;
using Sofomo.Domain.Models.Dtos;

namespace Sofomo.CQRS.Repositories
{
    public class LocationRepository(DatabaseContext _context) : ILocationRepository
    {
        public async Task AddAsync(double latitude, double longtitude)
        {
            await _context.Locations.AddAsync(new LocationDto { Latitude = latitude, Longitude = longtitude });
        }

        public async Task<LocationDto?> GetAsync(double latitude, double longtitude)
        {
            return await _context.Locations.SingleOrDefaultAsync(loc => loc.Latitude == latitude && loc.Longitude == longtitude);
        }

        public async Task<IEnumerable<LocationDto?>> GetAllAsync()
        {
            return await _context.Locations.ToListAsync();
        }

        public async Task DeleteAsync(double latitude, double longtitude)
        {
            await _context.Locations.Where(loc => loc.Latitude == latitude && loc.Longitude == longtitude).ExecuteDeleteAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
