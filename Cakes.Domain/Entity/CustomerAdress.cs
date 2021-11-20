namespace Cakes.Domain.Entity
{
    public class CustomerAdress : BaseEntity
    {
        public CustomerAdress() { }
        public CustomerAdress(string zipCode, string adress, int number, string? complement, string district, string city, string state, Customer customer)
        {
            ZipCode = zipCode;
            Adress = adress;
            Number = number;
            Complement = complement;
            District = district;
            City = city;
            State = state;
            Customer = customer;
        }

        public string ZipCode { get; private set; }
        public string Adress { get; private set; }
        public int Number { get; private set; }
        public string? Complement { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public Customer Customer { get; private set; }
    }
}
