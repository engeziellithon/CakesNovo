using Cakes.Domain.Commands.Interfaces;
using Cakes.Domain.Commands.Product;
using Cakes.Domain.Interfaces.Handlers;

namespace Cakes.Domain.Handlers
{
    public class ProductHandler
        : IHandler<CreateProductCommand>
    {
        public ICommandResult Handle(CreateProductCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
