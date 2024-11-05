using Sofomo.Commands.Shared;
using Sofomo.Repositories;

namespace Sofomo.Commands.Utils
{
    public interface ICommandHandler<in TCommand> : ICommand
    {
        public Task HandleAsync(TCommand command);
    }
}
