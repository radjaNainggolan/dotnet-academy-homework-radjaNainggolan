using Library.RadenRovcanin.Contracts.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace Library.RadenRovcanin.Contracts.Entities
{
    public class Person : IdentityUser<int>
    {
        public string FirstName { get; } = default!;

        public string LastName { get; } = default!;

        public int Age { get; } = default!;

        public Address Address { get; } = default!;

        public List<Book> RentedBooks { get; set; } = default!;

        public Person(string firstName, string lastName, string email, string userName, int age, Address address)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
            Age = age;
            Address = address;
        }

        public Person(int id, string firstName, string lastName, string email, string userName, int age, Address address)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
            Age = age;
            Address = address;
            RentedBooks = new List<Book>();
        }

        public Person()
        {
            RentedBooks = new List<Book>();
        }

        public void RentBook(Book book)
        {
            const int maxNumbersOfBooks = 4;

            if (RentedBooks.Count >= maxNumbersOfBooks)
            {
                throw new BookRentingException("Maximum number of book exceeded");
            }
            else if (book == null)
            {
                throw new EntityNotFoundException();
            }
            else if (RentedBooks.Contains(book))
            {
                throw new BookRentingException("Book already rented");
            }
            else if (book.Quantity == 0)
            {
                throw new BookRentingException("Book is not currently avaliable.");
            }
            else
            {
                RentedBooks.Add(book);
                book.RemoveFromShelf();
            }
        }

        public void ReturnBook(int bookId)
        {
            var book = RentedBooks.Find(b => b.Id == bookId);
            if (book == null)
            {
                throw new EntityNotFoundException("Book can not be found in person rented books");
            }

            RentedBooks.Remove(book);
            book.AddToShelf();
        }
    }
}
