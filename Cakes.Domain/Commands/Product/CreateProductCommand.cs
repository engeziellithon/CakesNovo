using Cakes.Domain.Commands.Interfaces;
using Flunt.Br;
using Flunt.Notifications;

namespace Cakes.Domain.Commands.Product
{
    public class CreateProductCommand : Notifiable<Notification>, ICommand
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? ProductCategory { get; set; }
        public decimal Price { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(Title, "Title", "Campo obrigatório!")
                .IsNotNull(ProductCategory, "ProductCategory", "Campo obrigatório!")
                .IsLowerOrEqualsThan(Price, 0, "Price", "O preço precisa ser maior que zero!"));

            if (!string.IsNullOrEmpty(ImageUrl))
                AddNotifications(new Contract().IsUrl(ImageUrl, "ImageUrl", "A imagen precisa ser um url válida!"));
        }
    }
}
