using Library.RadenRovcanin.Contracts;
using Library.RadenRovcanin.Contracts.Dtos;
using Library.RadenRovcanin.Contracts.Repositories;
using Library.RadenRovcanin.Contracts.Services;

namespace Library.RadenRovcanin.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly IUnitOfWork _iuow;

        public LibraryService(IUnitOfWork iuow)
        {
            _iuow = iuow;
        }

        public async Task<IEnumerable<BookDto>> GetAll()
        {
            var res = await _iuow.Books.GetAllAsync();
            var books = res
                .Select(b => new BookDto(
                b.Id,
                b.Title,
                b.Genre,
                b.Authors,
                b.Quantity));
            return books;
        }

        public async Task RentBook(int personId, int bookId)
        {
            var book = await _iuow.Books.GetByIdAsync(bookId);

            if (book == null)
            {
                throw new EntityNotFoundException($"Book with ID:{bookId} is not found in system.");
            }

            var person = await _iuow.People.GetByIdWithBooksAsync(personId);

            person.RentBook(book);

            await _iuow.SaveChangesAsync();
        }

        public async Task<IEnumerable<BookDto>> RentedBooks(int personId)
        {
            var person = await _iuow.People.GetByIdWithBooksAsync(personId);

            if (person == null)
            {
                throw new EntityNotFoundException($"Person with ID:{personId} is not found in system.");
            }

            var books = person.RentedBooks
                .Select(b => new BookDto(
                    b.Book.Id,
                    b.Book.Title,
                    b.Book.Genre,
                    b.Book.Authors,
                    b.Book.Quantity));

            return books;
        }

        public async Task ReturnBook(int personId, int bookId)
        {
            var person = await _iuow.People.GetByIdWithBooksAsync(personId);

            if (person == null)
            {
                throw new EntityNotFoundException($"Person with ID:{personId} is not found in system.");
            }

            person.ReturnBook(bookId);

            await _iuow.SaveChangesAsync();
        }
    }
}
