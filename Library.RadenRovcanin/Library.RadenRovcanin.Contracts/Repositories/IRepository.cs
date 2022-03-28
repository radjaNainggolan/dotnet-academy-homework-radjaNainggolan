namespace Library.RadenRovcanin.Contracts.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity?> GetByIdAsync(int id);

        void Add(TEntity entity);
    }
}
