namespace Library.RadenRovcanin.Contracts.Entities
{
    public class Person : BaseEntity
    {
        public int Id { get; set; } = default!;

        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public Address Address { get; set; } = default!;

        public Person()
        {
        }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            DateCreated = DateTime.Now;
        }
    }
}
