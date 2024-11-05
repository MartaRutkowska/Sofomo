using Microsoft.EntityFrameworkCore;
using Sofomo.Commands;
using Sofomo.Commands.Utils;
using Sofomo.Repositories;

namespace Sofomo.Handlers.CommandHandler
{
    public class AddCoordinatesCommandHandler(ILocationRepository _repository) : ICommandHandler<AddCoordinatesCommand>
    {
        public async Task HandleAsync(AddCoordinatesCommand command)
        {
            var location = await _repository.GetAsync(command.Latitude, command.Longtitude);
            if (location == null) await _repository.AddAsync(command.Latitude, command.Longtitude);
            await _repository.SaveChangesAsync();
        }
    }
}
