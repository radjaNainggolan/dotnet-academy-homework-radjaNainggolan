using Library.RadenRovcanin.Contracts.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.RadenRovcanin.Data.Db.Repositories
{
    public class BookRepository : Repository<Book>
    {
        public BookRepository(DbContext context) : base(context)
        {
        }
    }
}
