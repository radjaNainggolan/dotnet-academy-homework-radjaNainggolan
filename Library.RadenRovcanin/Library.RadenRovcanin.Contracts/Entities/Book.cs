using Library.RadenRovcanin.Contracts.Entities.Enumerate;
using Library.RadenRovcanin.Contracts.Exceptions;

namespace Library.RadenRovcanin.Contracts.Entities
{
    public class Book
    {
        public int Id { get; } = default!;

        public string Title { get; } = default!;

        public Genre Genre { get; } = default!;

        public string Authors { get; } = default!;

        public int Quantity { get; private set; } = default!;

        public List<Person> People { get; } = default!;

        public Book(
            string title,
            Genre genre,
            string authors,
            int quantity)
        {
            Title = title;
            Genre = genre;
            Authors = authors;
            Quantity = quantity;
        }

        public Book(
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
            Quantity = quantity;
        }

        public bool IsAvaliable() => Quantity > 0;

        public void AddToShelf()
        {
            Quantity++;
        }

        public void RemoveFromShelf()
        {
            if (!IsAvaliable())
            {
                throw new BookNotAvaliableException(this);
            }
            else
            {
                Quantity--;
            }
        }
    }
}
