using Library.RadenRovcanin.Contracts.Entities;

namespace Library.RadenRovcanin.Contracts.Repositories
{
    public interface IUnitOfWork
    {
        IPersonRepository People { get; }
        IRepository<Book> Books { get; }

        Task SaveChangesAsync();
    }
}
