using Library.RadenRovcanin.Contracts.Entities;
using Library.RadenRovcanin.Contracts.Entities.Enumerate;

namespace Library.RadenRovcanin.Services.Tests
{
    public static class BookMock
    {
        public static Book Build(int quantity = 10)
        {
            return new Book(
                0,
                "Title",
                Genre.Classic,
                "Author",
                quantity);
        }
    }
}
