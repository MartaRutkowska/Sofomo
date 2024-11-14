using Sofomo.CQRS.Commands;
using Sofomo.CQRS.Repositories.Shared;

namespace Sofomo.CQRS.Handlers.CommandHandlers
{
    public class UpdateWeatherCommandHandler(IUnitOfWork UnitOfWork)
    {
        public async Task HandleAsync(UpdateWeatherCommand command)
        {
            await UnitOfWork.WeatherRepository.UpdateForCoordinates(command.Weather, command.Location);
            await UnitOfWork.Complete();
        }
    }
}
