using Microsoft.AspNetCore.Identity;

namespace Library.RadenRovcanin.Contracts.Entities
{
    public class Person : IdentityUser<int>
    {
        public override int Id { get; set; } = default!;

        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public string FullName { get; set; } = default!;
        public Address Address { get; set; } = default!;

        public Person()
        {
        }

        public Person(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            FullName = firstName + " " + lastName;
            Email = email;
        }
    }
}
