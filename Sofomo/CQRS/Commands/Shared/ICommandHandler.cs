namespace Sofomo.CQRS.Commands.Shared
{
    public interface ICommandHandler<in TCommand> : ICommand
    {
        public Task HandleAsync(TCommand command);
    }
}
