using MediatR;
using Sofomo.CQRS.Commands;
using Sofomo.CQRS.Repositories.Shared;
using Sofomo.Domain.Models.Dtos;

namespace Sofomo.CQRS.Handlers.CommandHandlers
{
    public class AddCoordinatesCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddCoordinatesCommand>
    {
        public async Task Handle(AddCoordinatesCommand command, CancellationToken cancellationToken)
        {
            var location = await unitOfWork.LocationRepository.GetByCoordinatesAsync(command.Latitude, command.Longitude);
            var locationDto = new LocationDto { Latitude = command.Latitude, Longitude = command.Longitude };
            if (location == null) await unitOfWork.LocationRepository.AddAsync(locationDto);
            await unitOfWork.Complete();
        }
    }
}
