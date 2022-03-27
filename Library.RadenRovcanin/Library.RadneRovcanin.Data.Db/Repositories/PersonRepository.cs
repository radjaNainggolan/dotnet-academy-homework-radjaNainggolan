using System.Linq;
using Library.RadenRovcanin.Contracts.Entities;
using Library.RadenRovcanin.Contracts.Repositories;
using Library.RadneRovcanin.Data.Db.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Library.RadenRovcanin.Data.Db.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public async Task<IList<Person>> GetByCityAsync(string city)
        {
            return await _dbSet.Where(p => p.Address.City.Equals(city, StringComparison.CurrentCultureIgnoreCase)).Include(p => p.Address).ToListAsync();
        }
    }
}
