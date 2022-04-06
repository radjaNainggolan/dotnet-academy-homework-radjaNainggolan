using Library.RadenRovcanin.Contracts.Entities.Enumerate;

namespace Library.RadenRovcanin.Contracts.Dtos
{
    public class BookDto
    {
        public int Id { get; set; } = default!;

        public string Title { get; set; } = default!;

        public Genre Genre { get; set; } = default!;

        public string Authors { get; set; } = default!;

        public int Qunatity { get; set; } = default!;

        public BookDto(
            int id,
            string title,
            Genre genre,
            string authors,
            int quantity)
        {
            Id = id;
            Title = title;
            Genre = genre;
            Authors = authors;
            Qunatity = quantity;
        }
    }
}
