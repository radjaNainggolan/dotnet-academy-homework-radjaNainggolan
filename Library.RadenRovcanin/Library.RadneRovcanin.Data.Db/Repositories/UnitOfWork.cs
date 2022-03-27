using Library.RadenRovcanin.Contracts.Entities;
using Library.RadenRovcanin.Contracts.Repositories;
using Library.RadneRovcanin.Data.Db.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Library.RadenRovcanin.Data.Db.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IRepository<Person> people;
        private readonly DbContext _dbContext;

        public UnitOfWork(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public IRepository<Person> People
            => people ?? new Repository<Person>(_dbContext);
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
