using Library.RadenRovcanin.Contracts.Entities;
using Library.RadenRovcanin.Contracts.Repositories;
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
