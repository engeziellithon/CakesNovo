using Cakes.Domain.Commands.Interfaces;

namespace Cakes.Domain.Interfaces.Handlers
{
    public interface IHandler<in T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}