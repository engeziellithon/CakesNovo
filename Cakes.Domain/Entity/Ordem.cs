using Cakes.Domain.Enums;


namespace Cakes.Domain.Entity
{
    public class Ordem : BaseEntity
    {
        public Ordem() { }
        public Ordem(Customer customer, decimal deliveryFee, Discount? discount)
        {
            Customer = customer;
            Date = DateTime.UtcNow;
            Number = Guid.NewGuid().ToString().Substring(0, 16);
            OrdemItem = new List<OrdemItem>();
            Discount = discount;
            Status = EOrderStatus.WaitingPayment;
            DeliveryFee = deliveryFee;
        }

        public Customer Customer { get; private set; }
        public DateTime Date { get; private set; }
        public string Number { get; private set; }
        public IList<OrdemItem> OrdemItem { get; private set; }
        public Discount? Discount { get; private set; }
        public EOrderStatus Status { get; private set; }
        public decimal? DeliveryFee { get; private set; }


        public void AddItem(Product product, int quantity)
        {
            var item = new OrdemItem(product, quantity);

            OrdemItem.Add(item);
        }

        public decimal Total()
        {
            decimal total = OrdemItem?.Sum(item => item.Total()) ?? 0;

            total += DeliveryFee ?? 0;
            total -= Discount?.Value() ?? 0;

            return total;
        }

        public void Pay(decimal amount)
        {
            if (amount == Total())
                Status = EOrderStatus.WaitingDelivery;
        }

        public void Cancel()
        {
            Status = EOrderStatus.Canceled;
        }

        public void Delivered()
        {
            Status = EOrderStatus.Delivered;
        }
    }
}