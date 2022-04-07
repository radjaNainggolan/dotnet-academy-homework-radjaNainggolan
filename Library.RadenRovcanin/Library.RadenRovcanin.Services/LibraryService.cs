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

        public async Task RentBook(int PersonId, int BookId)
        {
            var book = await _iuow.Books.GetByIdAsync(BookId);

            var person = await _iuow.People.GetByIdWithBooksAsync(PersonId);

            person.RentBook(book);

            await _iuow.SaveChangesAsync();
        }

        public async Task<IEnumerable<BookDto>> RentedBooks(int PersonId)
        {
            var person = await _iuow.People.GetByIdWithBooksAsync(PersonId);

            var books = person.RentedBooks
                .Select(b => new BookDto(
                    b.Id,
                    b.Title,
                    Enum.GetName(typeof(Genre), b.Genre),
                    b.Authors,
                    b.Quantity));

            return books;
        }

        public async Task ReturnBook(int PersonId, int BookId)
        {
            var person = await _iuow.People.GetByIdWithBooksAsync(PersonId);

            person.ReturnBook(BookId);

            await _iuow.SaveChangesAsync();

        }
    }
}
