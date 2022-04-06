using Library.RadenRovcanin.Contracts.Dtos;

namespace Library.RadenRovcanin.Contracts.Services
{
    public interface ILibraryService
    {
        public Task<IEnumerable<BookDto>> GetAll();

        public Task RentBook(int PersonId, int BookId);

        public Task ReturnBook(int PersonId, int BookId);

        public Task<IEnumerable<BookDto>> RentedBooks(int PersonId);
    }
}
