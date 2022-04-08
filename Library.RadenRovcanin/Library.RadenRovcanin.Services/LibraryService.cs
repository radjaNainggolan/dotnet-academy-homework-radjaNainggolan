using Library.RadenRovcanin.Contracts.Dtos;
using Library.RadenRovcanin.Contracts.Entities.Enumerate;
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
                Enum.GetName(typeof(Genre), b.Genre),
                b.Authors,
                b.Quantity));
            return books;
        }

        public async Task RentBook(int personId, int bookId)
        {
            var book = await _iuow.Books.GetByIdAsync(bookId);

            var person = await _iuow.People.GetByIdWithBooksAsync(personId);

            person.RentBook(book);

            await _iuow.SaveChangesAsync();
        }

        public async Task<IEnumerable<BookDto>> RentedBooks(int personId)
        {
            var person = await _iuow.People.GetByIdWithBooksAsync(personId);

            var books = person.RentedBooks
                .Select(b => new BookDto(
                    b.Id,
                    b.Title,
                    Enum.GetName(typeof(Genre), b.Genre),
                    b.Authors,
                    b.Quantity));

            return books;
        }

        public async Task ReturnBook(int personId, int bookId)
        {
            var person = await _iuow.People.GetByIdWithBooksAsync(personId);

            person.ReturnBook(bookId);

            await _iuow.SaveChangesAsync();
        }
    }
}
