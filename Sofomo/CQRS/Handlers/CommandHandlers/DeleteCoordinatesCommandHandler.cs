using Sofomo.CQRS.Commands;
using Sofomo.CQRS.Repositories;

namespace Sofomo.CQRS.Handlers.CommandHandlers
{
    public class DeleteCoordinatesCommandHandler(ILocationRepository _repository)
    {
        public async Task HandleAsync(DeleteCoordinatesCommand command)
        {
            await _repository.DeleteAsync(command.Latitude, command.Longtitude);
            await _repository.SaveChangesAsync();
        }
    }
}
