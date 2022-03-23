namespace Library.RadenRovcanin.Contracts.Entities
{
    public class Person
    {
        public int Id { get; set; } = default!;

        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public Address Address { get; set; } = default!;

        public Person()
        {
        }

        public Person(int id, string firstName, string lastName, Address address)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
        }
    }
}
