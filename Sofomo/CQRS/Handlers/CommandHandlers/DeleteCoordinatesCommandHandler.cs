using Sofomo.CQRS.Commands;
using Sofomo.CQRS.Repositories.Shared;

namespace Sofomo.CQRS.Handlers.CommandHandlers
{
    public class DeleteCoordinatesCommandHandler(IUnitOfWork UnitOfWork)
    {
        public async Task HandleAsync(DeleteCoordinatesCommand command)
        {
            var locationDto = await UnitOfWork.LocationRepository.GetByCoordinatesAsync(command.Latitude, command.Longtitude);
            if(locationDto != null) UnitOfWork.LocationRepository.Remove(locationDto);
            await UnitOfWork.Complete();
        }
    }
}
