using MediatR;
using Sofomo.CQRS.Commands;
using Sofomo.CQRS.Repositories.Shared;

namespace Sofomo.CQRS.Handlers.CommandHandlers
{
    public class UpdateWeatherCommandHandler(IUnitOfWork UnitOfWork) : IRequestHandler<UpdateWeatherCommand>
    {
        public async Task Handle(UpdateWeatherCommand command, CancellationToken cancellationToken)
        {
            await UnitOfWork.WeatherRepository.UpdateForCoordinates(command.Weather, command.Location);
            await UnitOfWork.Complete();
        }
    }
}
