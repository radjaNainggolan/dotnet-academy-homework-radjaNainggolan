using Library.RadenRovcanin.Contracts.Entities;

namespace Library.RadenRovcanin.Contracts.Repositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        public Task<IEnumerable<Person>> GetByCityAsync(string city);
        public Task<IEnumerable<Person>> GetAllWithAddressAsync();
        public Task<Person?> GetByIdWithAddressAsync(int id);
        public Task<Person?> GetByIdWithBooksAsync(int id);
        public Task<IEnumerable<Person>> GetPeopleWithBookRentedBeforeDate(DateTime date);
    }
}
