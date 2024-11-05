using Sofomo.CQRS.Commands;
using Sofomo.CQRS.Commands.Shared;
using Sofomo.CQRS.Repositories;

namespace Sofomo.CQRS.Handlers.CommandHandlers
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
