namespace Cakes.Domain.Entity
{
    public class OrdemItem : BaseEntity
    {
        public OrdemItem() { }
        public OrdemItem(Product product, int quantity)
        {
            Product = product;
            Price = Product?.Price ?? 0;
            Quantity = quantity;
        }

        public Product Product { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
        public Ordem Ordem { get; set; }

        public decimal Total() => Price * Quantity;
    }
}