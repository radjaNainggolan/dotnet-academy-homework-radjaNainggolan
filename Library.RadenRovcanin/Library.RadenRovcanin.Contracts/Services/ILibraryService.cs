using Library.RadenRovcanin.Contracts.Dtos;

namespace Library.RadenRovcanin.Contracts.Services
{
    public interface ILibraryService
    {
        public Task<IEnumerable<BookDto>> GetAll();

        public Task RentBook(int personId, int bookId);

        public Task ReturnBook(int personId, int bookId);

        public Task<IEnumerable<BookDto>> RentedBooks(int personId);
    }
}
