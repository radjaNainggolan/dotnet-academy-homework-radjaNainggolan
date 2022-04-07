using Library.RadenRovcanin.Contracts.Entities;

namespace Library.RadenRovcanin.Contracts.Exceptions
{
    public class BookNotAvaliableException : Exception
    {
        public Book Book { get; }
        public BookNotAvaliableException(Book book) : base($"Book {book.Title} is not avaliable")
        {
            Book = book;
        }
    }
}
