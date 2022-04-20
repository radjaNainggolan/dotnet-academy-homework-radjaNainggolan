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
            //PersonBook personBook = new PersonBook(_sut, book);
            // act
            _sut.RentBook(book);
            // assert
            _sut.RentedBooks.Should().Contain(_sut.RentedBooks[0]);
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
            PersonBook personBook = new PersonBook(_sut, book);
            _sut.RentedBooks.Add(personBook);

            // act
            _sut.ReturnBook(book.Id);

            // assert
            book.Quantity.Should().Be(11);
            bool conatains = _sut.RentedBooks.Contains(personBook);
            conatains.Should().BeFalse();
        }

        [Fact]
        public void ReturnBook_WhenBookIsNotInRentedBooks_ThenThrowException()
        {
            // arrange
            const int bookId = 1;

            // act
            Action action = () => _sut.ReturnBook(bookId);

            // assert
            action.Should().Throw<EntityNotFoundException>();
        }
    }
}
