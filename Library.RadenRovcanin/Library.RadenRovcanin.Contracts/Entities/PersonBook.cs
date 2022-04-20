namespace Library.RadenRovcanin.Contracts.Entities
{
    public class PersonBook
    {
        public int PersonId { get; } = default!;

        public Person Person { get; } = default!;

        public int BookId { get; } = default!;

        public Book Book { get; } = default!;

        public DateTime DateRented { get; } = default!;

        public PersonBook(Person person, Book book)
        {
            Person = person;
            Book = book;
            DateRented = DateTime.UtcNow;
        }

        private PersonBook()
        {
        }
    }
}
