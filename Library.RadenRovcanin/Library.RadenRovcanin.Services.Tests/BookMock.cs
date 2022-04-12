using Library.RadenRovcanin.Contracts.Entities;
using Library.RadenRovcanin.Contracts.Entities.Enumerate;

namespace Library.RadenRovcanin.Services.Tests
{
    public class BookMock
    {

        public static Book Build(int quantity = 10)
        {
            return new Book(
                1,
                "Title",
                Genre.Classic,
                "Author",
                quantity);
        }
    }
}
