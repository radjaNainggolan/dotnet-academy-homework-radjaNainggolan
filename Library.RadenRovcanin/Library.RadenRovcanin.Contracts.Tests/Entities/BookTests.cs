using FluentAssertions;
using Library.RadenRovcanin.Contracts.Entities;
using Library.RadenRovcanin.Contracts.Entities.Enumerate;
using Library.RadenRovcanin.Contracts.Exceptions;
using Library.RadenRovcanin.Services.Tests;
using Xunit;

namespace Library.RadenRovcanin.Contracts.Tests.Entities
{
    public class BookTests
    {

        private readonly Book _sut;

        public BookTests()
        {
            _sut = new Book();
        }

        [Fact]
        public void ConstructorBook_WhenParamsAreValid_ThenSuccessfully()
        {
            var bookMock = BookMock.Build();

            var book = new Book(bookMock.Title, bookMock.Genre, bookMock.Authors, bookMock.Quantity);

            bookMock.Should().BeEquivalentTo(book);
        }

        [Theory]
        [InlineData("    ", Genre.Fantasy, "Test Author", 10, "Title is required")]
        [InlineData(null, Genre.Fantasy, "Test Author", 10, "Title is required")]
        [InlineData("Test Book 2", Genre.Horror, "", 1, "Authors are required")]
        [InlineData("Test Book 2", Genre.Horror, "Test Author", -5, "Quantity must be greater than 0")]
        public void ConstructorBook_WhenParamsNotValid_ThenThrowExcpetions(
            string title,
            Genre genre,
            string authors,
            int quantity,
            string expectedExcpetionMsg)
        {
            // act
            var error = Assert.Throws<ArgumentException>(() =>
            new Book(title, genre, authors, quantity));

            // assert
            error.Message.Should().Be(expectedExcpetionMsg);

            // assert fluent
            Action bookCreation = () => new Book(title, genre, authors, quantity);
            bookCreation.Should().Throw<ArgumentException>().WithMessage(expectedExcpetionMsg);
        }

        [Fact]
        public void IsAvaliable_WhenQuantityIsGreatherThan0_ThenReturnTrue()
        {
            // arrange
            var book = BookMock.Build();

            // act
            var actualResult = book.IsAvaliable();

            // assert
            actualResult.Should().BeTrue();
        }

        [Fact]
        public void IsAvaliable_WhenQuantityIs0_ThenReturnFalse()
        {
            // arrange
            var book = BookMock.Build(0);

            // act
            var actualResult = book.IsAvaliable();

            // assert
            actualResult.Should().BeFalse();
        }

        [Fact]
        public void AddToShelf_ThenIncreasesBookQunatity()
        {
            // arrange
            var book = BookMock.Build(0);

            // act
            book.AddToShelf();

            // assert
            book.Quantity.Should().Be(1);
        }

        [Fact]
        public void RemoveFromShelf_WhenAvaliable_ThenDecresesBookQunantity()
        {
            // arrnge
            var book = BookMock.Build(1);

            // act
            book.RemoveFromShelf();

            // assert
            book.Quantity.Should().Be(0);
        }

        [Fact]
        public void RemoveFromShelf_WhenNotAvaliable_ThenThrowException()
        {
            // arrange
            var book = BookMock.Build(0);

            // act
            Action action = () => book.RemoveFromShelf();

            // assert
            action.Should().Throw<BookNotAvaliableException>();
        }
    }
}
