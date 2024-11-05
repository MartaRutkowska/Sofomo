using Sofomo.CQRS.Commands;
using Sofomo.CQRS.Repositories;

namespace Sofomo.CQRS.Handlers.CommandHandlers
{
    public class UpdateWeatherCommandHandler(IWeatherRepository _repository)
    {
        public async Task HandleAsync(UpdateWeatherCommand command)
        {
            await _repository.Update(command.Weather, command.Location);
            await _repository.SaveChangesAsync();
        }
    }
}
