namespace Cakes.Domain.Entity
{
    public class Customer : BaseEntity
    {
        public Customer(string name, string email, Guid userId)
        {
            Name = name;
            Email = email;
            UserId = userId;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public Guid UserId { get; private set; }
        public List<CustomerAdress> CustomersAdresses { get; set; }
    }
}