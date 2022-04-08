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

        public async Task<IEnumerable<Person>> GetAllWithAddressAsync()
        {
            IQueryable<Person> query = _dbSet
                .Include(a => a.Address);
            return await query.ToListAsync();
        }

        public async Task<Person?> GetByIdWithAddressAsync(int id)
        {
            IQueryable<Person> query = _dbSet
                .Where(p => p.Id == id)
                .Include(a => a.Address);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Person?> GetByIdWithBooksAsync(int id)
        {
            IQueryable<Person> query = _dbSet
                .Where(p => p.Id == id)
                .Include(b => b.RentedBooks);
            return await query.FirstOrDefaultAsync();
        }
    }
}
