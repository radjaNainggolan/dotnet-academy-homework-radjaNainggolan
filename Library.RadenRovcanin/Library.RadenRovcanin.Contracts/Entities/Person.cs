using Library.RadenRovcanin.Contracts.Exceptions;
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

        public List<Book> RentedBooks { get; set; } = default!;

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

        public void RentBook(Book book)
        {
            const int maxNumbersOfBooks = 4;

            if (RentedBooks.Count >= maxNumbersOfBooks)
            {
                throw new BookRentingException("Maximum number of book exceeded");
            }
            else if (RentedBooks.Contains(book))
            {
                throw new BookRentingException("Book already rented");
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
                throw new EntityNotFoundException("Book can not be found in person rented books");
            }

            RentedBooks.Remove(book);
            book.AddToShelf();

        }
    }
}
