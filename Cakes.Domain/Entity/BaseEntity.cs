using Cakes.Domain.Commands.Interfaces;
using Flunt.Notifications;

namespace Cakes.Domain.Entity
{
    public abstract class BaseEntity : Notifiable<Notification>, ICommand
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}