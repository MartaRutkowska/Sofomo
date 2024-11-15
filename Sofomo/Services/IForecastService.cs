using Sofomo.Domain.Models.Request;
using Sofomo.Domain.Models.Response;

namespace Sofomo.Services
{
    public interface IForecastService
    {
        public Task<Forecast?> Get(Coordinates coordinates, CancellationToken cancellationToken);

        public Task<List<Forecast?>> GetAll(CancellationToken cancellationToken);

        public Task<bool> AddCoordinates(Coordinates coordinates, CancellationToken cancellationToken);

        public Task DeleteCoordinatesAsync(Coordinates coordinates, CancellationToken cancellationToken);
    }
}
