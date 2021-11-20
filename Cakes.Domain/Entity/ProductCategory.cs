namespace Cakes.Domain.Entity
{
    public class ProductCategory : BaseEntity
    {
        public ProductCategory() { }
        public ProductCategory(string name, bool active)
        {
            Name = name;
            Active = active;
            Product = new List<Product>();
        }

        public string Name { get; private set; }
        public bool Active { get; private set; }
        public List<Product> Product { get; set; }
    }
}
