namespace Cakes.Domain.Entity
{
    public class Product : BaseEntity
    {
        public Product() { }
        public Product(string title, decimal price, ProductCategory productCategory, string? description = null, string? imageUrl = null, bool active = true)
        {
            Title = title;
            Price = price;
            Active = active;
            ProductCategory = productCategory;
            Description = description;
            ImageUrl = imageUrl;
        }

        public string Title { get; private set; }
        public string? Description { get; private set; }
        public string? ImageUrl { get; private set; }
        public ProductCategory ProductCategory { get; private set; }
        public decimal Price { get; private set; }
        public bool Active { get; private set; }
    }
}