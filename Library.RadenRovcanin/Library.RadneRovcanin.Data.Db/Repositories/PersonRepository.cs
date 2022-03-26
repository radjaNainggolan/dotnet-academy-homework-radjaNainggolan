using Library.RadenRovcanin.Contracts.Entities;
using Library.RadenRovcanin.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Library.RadenRovcanin.Data.Db.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        protected readonly DbSet<Person> _dbSet;

        public PersonRepository(DbContext dbContext)
        {
            _dbSet = dbContext.Set<Person>();
        }

        public void Add(Person person)
        {
            _dbSet.Add(person);
        }

        public async Task<IList<Person>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<ICollection<Person>> GetByCityAsync(string city)
        {
            return await _dbSet.Where(p => p.Address.City.Equals(city, StringComparison.CurrentCultureIgnoreCase)).ToListAsync();
        }

        public async Task<Person?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
