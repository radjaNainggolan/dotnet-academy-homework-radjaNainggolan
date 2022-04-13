using FluentAssertions;
using Library.RadenRovcanin.Contracts.Entities;
using Library.RadenRovcanin.Contracts.Exceptions;
using Library.RadenRovcanin.Services.Tests;
using Xunit;

namespace Library.RadenRovcanin.Contracts.Tests
{
    public class PersonTests
    {
        private readonly Person _sut;

        public PersonTests()
        {
            _sut = new Person();
        }

        [Fact]
        public void RentBook_WhenBookAvaliable_DecresesBookQunatity()
        {
            // arrange
            var book = BookMock.Build(10);
            // act
            _sut.RentBook(book);
            // assert
            book.Quantity.Should().Be(9);
        }

        [Fact]
        public void RentBook_WhenBookNotAvaliable_ThenThrowException()
        {
            // arrange
            var book = BookMock.Build(0);

            // act
            Action action = () => _sut.RentBook(book);

            // assert
            action.Should().Throw<BookRentingException>();
        }

        [Fact]
        public void ReturnBook_WhenBookIsInRentedBooks_IncreasesBookQunatity()
        {
            // arrange
            var book = BookMock.Build(10);
            _sut.RentBook(book);
            // act
            _sut.ReturnBook(book.Id);

            // assert
            book.Quantity.Should().Be(10);
        }

        [Fact]
        public void ReturnBook_WhenBookIsNotInRentedBooks_ThenThrowException()
        {
            // arrange
            int bookId = 1;

            // act
            Action action = () => _sut.ReturnBook(bookId);

            action.Should().Throw<EntityNotFoundException>();
        }
    }
}
