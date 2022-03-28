using Library.RadenRovcanin.Contracts.Entities;

namespace Library.RadenRovcanin.Contracts.Repositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        public Task<IEnumerable<Person>> GetByCityAsync(string city);
    }
}
