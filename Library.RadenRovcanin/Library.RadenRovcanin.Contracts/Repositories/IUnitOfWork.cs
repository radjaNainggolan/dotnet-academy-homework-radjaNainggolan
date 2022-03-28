namespace Library.RadenRovcanin.Contracts.Repositories
{
    public interface IUnitOfWork
    {
        IPersonRepository People { get; }

        Task SaveChangesAsync();
    }
}
