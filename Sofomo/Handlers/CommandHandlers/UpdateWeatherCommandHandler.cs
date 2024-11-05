using Sofomo.Commands.Utils;
using Sofomo.Commands;
using Sofomo.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Sofomo.Handlers.CommandHandlers
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
