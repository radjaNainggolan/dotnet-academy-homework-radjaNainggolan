using Library.RadenRovcanin.Contracts.Repositories;
using Library.RadneRovcanin.Data.Db.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Library.RadenRovcanin.Data.Db.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IPersonRepository people = default!;
        private readonly DbContext _dbContext;

        public UnitOfWork(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public IPersonRepository People
            => people ?? new PersonRepository(_dbContext);
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
