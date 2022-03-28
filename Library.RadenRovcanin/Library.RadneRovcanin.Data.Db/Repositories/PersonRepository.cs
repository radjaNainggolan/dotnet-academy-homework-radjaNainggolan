using Library.RadenRovcanin.Contracts.Entities;
using Library.RadenRovcanin.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Library.RadenRovcanin.Data.Db.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Person>> GetByCityAsync(string city)
        {
            IQueryable<Person> query = _dbSet
                .Where(p => p.Address.City == city)
                .Include(a => a.Address);
            return await query.ToListAsync();
        }
    }
}
