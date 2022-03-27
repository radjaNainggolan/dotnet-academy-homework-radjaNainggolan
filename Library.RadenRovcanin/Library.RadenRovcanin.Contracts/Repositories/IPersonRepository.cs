using Library.RadenRovcanin.Contracts.Entities;

namespace Library.RadenRovcanin.Contracts.Repositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        Task<IList<Person>> GetByCityAsync(string city);
    }
}
