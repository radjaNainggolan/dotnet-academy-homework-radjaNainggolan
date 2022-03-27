using Library.RadenRovcanin.Contracts.Entities;

namespace Library.RadenRovcanin.Contracts.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<Person> People { get; }

        Task SaveChangesAsync();
    }
}
