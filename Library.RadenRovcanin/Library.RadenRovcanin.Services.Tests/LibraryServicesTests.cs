using FluentAssertions;
using Library.RadenRovcanin.Contracts.Dtos;
using Library.RadenRovcanin.Contracts.Entities;
using Library.RadenRovcanin.Contracts.Repositories;
using Library.RadenRovcanin.Services;
using Moq;
using Xunit;

namespace Library.RadenRovcanin.Services.Tests
{
    public class LibraryServicesTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly LibraryService _sut;

        public LibraryServicesTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _sut = new LibraryService(_unitOfWorkMock.Object);
        }

        [Fact]
        public async Task GetBooks_WhenRepositoryReturnsData_ThenMapToDto()
        {
            // arrange
            var book = BookMock.Build();
            var books = new[] { book };

            _unitOfWorkMock.Setup(b => b.Books.GetAllAsync()).ReturnsAsync(books);

            var expectedResult = new[]
            {
                new BookDto(
                    book.Id,
                    book.Title,
                    book.Genre,
                    book.Authors,
                    book.Quantity),
            };

            // act
            var actualResult = await _sut.GetAll();

            // assert
            expectedResult.Should().BeEquivalentTo(actualResult);
        }
    }
}
