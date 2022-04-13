using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Library.RadenRovcanin.Contracts.Entities.Enumerate;
using Library.RadenRovcanin.Contracts.Exceptions;

namespace Library.RadenRovcanin.Contracts.Entities
{
    public class Book
    {
        public int Id { get; } = default!;

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; } = default!;

        [Required(ErrorMessage = "Genre is required")]
        public Genre Genre { get; } = default!;

        [Required(ErrorMessage = "Authors are required")]
        public string Authors { get; } = default!;

        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; private set; } = default!;

        public List<Person> People { get; } = default!;

        public Book()
        {
        }

        public Book(
            string title,
            Genre genre,
            string authors,
            int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than 0");
            }

            if (String.IsNullOrWhiteSpace(title) || String.IsNullOrEmpty(title))
            {
                throw new ArgumentException("Title is required");
            }

            if (String.IsNullOrWhiteSpace(authors) || String.IsNullOrEmpty(authors))
            {
                throw new ArgumentException("Authors are required");
            }

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
