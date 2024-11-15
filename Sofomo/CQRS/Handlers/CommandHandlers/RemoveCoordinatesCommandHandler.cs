using MediatR;
using Sofomo.CQRS.Commands;
using Sofomo.CQRS.Repositories.Shared;

namespace Sofomo.CQRS.Handlers.CommandHandlers
{
    public class RemoveCoordinatesCommandHandler(IUnitOfWork UnitOfWork) : IRequestHandler<RemoveCoordinatesCommand>
    {
        public async Task Handle(RemoveCoordinatesCommand command, CancellationToken cancellationToken)
        {
            var locationDto = await UnitOfWork.LocationRepository.GetByCoordinatesAsync(command.Latitude, command.Longtitude);
            if (locationDto != null) UnitOfWork.LocationRepository.Remove(locationDto);
            await UnitOfWork.Complete();
        }
    }
}
