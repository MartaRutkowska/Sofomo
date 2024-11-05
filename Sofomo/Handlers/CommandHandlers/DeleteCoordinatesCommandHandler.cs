using Sofomo.Commands;
using Sofomo.Commands.Utils;
using Sofomo.Repositories;

namespace Sofomo.Handlers.CommandHandler
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
