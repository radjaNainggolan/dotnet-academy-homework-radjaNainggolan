using Microsoft.AspNetCore.Identity;

namespace Library.RadenRovcanin.Contracts.Entities
{
    public class Person : IdentityUser<int>
    {
        public string FirstName { get; } = default!;

        public string LastName { get; } = default!;

        public int Age { get; } = default!;

        public string FullName { get; } = default!;

        public Address Address { get; } = default!;

        public List<Book> RentedBooks { get; } = default!;

        public Person()
        {
        }

        public Person(string firstName, string lastName, string username, string email, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            FullName = firstName + " " + lastName;
            UserName = username;
            Email = email;
            Age = age;
        }
    }
}
