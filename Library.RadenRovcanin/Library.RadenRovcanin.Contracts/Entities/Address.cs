namespace Library.RadenRovcanin.Contracts.Entities
{
    public class Address
    {
        public string Street { get; set; } = default!;

        public string City { get; set; } = default!;

        public string Country { get; set; } = default!;

        public Person Person { get; set; } = default!;
        public Address(string street, string city, string country)
        {
            Street = street;
            City = city;
            Country = country;
        }
    }
}
