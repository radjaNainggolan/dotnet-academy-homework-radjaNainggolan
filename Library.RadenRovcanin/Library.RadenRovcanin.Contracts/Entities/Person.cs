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
            RentedBooks = new List<Book>();
        }

        public void RentBook(Book book)
        {
            const int maxNumbersOfBooks = 4;

            if (RentedBooks.Count >= maxNumbersOfBooks)
            {

            }
            else if (RentedBooks.Contains(book))
            {

            }
            else
            {
                RentedBooks.Add(book);
                book.RemoveFromShelf();
            }
        }

        public void ReturnBook(int BookId)
        {
            var book = RentedBooks.Find(b => b.Id == BookId);
            if (book == null)
            {

            }
            RentedBooks.Remove(book);
            book.AddToShelf();

        }
    }
}
