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

        public Task RentBook(int PersonId, int BookId)
        {
            var book = _iuow.Books.GetByIdAsync(BookId);

            var person = _iuow.People.GetByIdAsync(PersonId);

            
        }

        public Task<IEnumerable<BookDto>> RentedBooks()
        {
            throw new NotImplementedException();
        }

        public Task ReturnBook(int PersonId, int BookId)
        {
            throw new NotImplementedException();
        }
    }
}
