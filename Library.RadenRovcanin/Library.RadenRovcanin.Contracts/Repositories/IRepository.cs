namespace Library.RadenRovcanin.Contracts.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IList<TEntity>> GetAllAsync();

        Task<TEntity?> GetByIdAsync(int id);

        void Add(TEntity entity);
    }
}
