using Sofomo.CQRS.Commands;
using Sofomo.CQRS.Commands.Shared;
using Sofomo.CQRS.Repositories;
using Sofomo.CQRS.Repositories.Shared;
using Sofomo.Domain.Models.Dtos;

namespace Sofomo.CQRS.Handlers.CommandHandlers
{
    public class AddCoordinatesCommandHandler(IUnitOfWork unitOfWork) : ICommandHandler<AddCoordinatesCommand>
    {
        public async Task HandleAsync(AddCoordinatesCommand command)
        {
            var location = await unitOfWork.LocationRepository.GetByCoordinatesAsync(command.Latitude, command.Longitude);
            var locationDto = new LocationDto { Latitude = command.Latitude, Longitude = command.Longitude };
            if (location == null) await unitOfWork.LocationRepository.AddAsync(locationDto);
            await unitOfWork.Complete();
        }
    }
}
