using MediatR;
using Sofomo.CQRS.Commands;
using Sofomo.CQRS.Repositories.Shared;

namespace Sofomo.CQRS.Handlers.CommandHandlers
{
    public class UpdateWeatherCommandHandler(IUnitOfWork UnitOfWork) : IRequestHandler<UpdateWeatherCommand>
    {
        public async Task Handle(UpdateWeatherCommand command, CancellationToken cancellationToken)
        {
            var location = await UnitOfWork.LocationRepository.GetByCoordinatesAsync(command.Location.Latitude, command.Location.Longitude);
            if (location == null) return;

            await UnitOfWork.WeatherRepository.UpdateForCoordinates(command.Weather, command.Location.Id);
            await UnitOfWork.Complete();
        }
    }
}
