using Library.RadenRovcanin.Contracts.Dtos;

namespace Library.RadenRovcanin.Contracts.Services
{
    public interface ILibraryService
    {
        public Task<IEnumerable<BookDto>> GetAll();

        public Task Rent(int id);

        public Task Return(int id);

        public Task<IEnumerable<BookDto>> RentedBooks();
    }
}
