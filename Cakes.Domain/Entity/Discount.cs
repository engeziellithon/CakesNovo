namespace Cakes.Domain.Entity
{
    public class Discount : BaseEntity
    {
        public Discount(string code, decimal amount, DateTime expire, bool active)
        {
            Code = code;
            Amount = amount;
            Expire = expire;
            Active = active;
        }

        public string Code { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime Expire { get; private set; }
        public bool Active { get; private set; }
        public List<Ordem> Ordems { get; private set; }

        public bool IsNotExpire()
        {
            return DateTime.Compare(DateTime.UtcNow, Expire) < 0;
        }

        public decimal Value()
        {
            return IsValid ? Amount : 0;
        }
    }
}