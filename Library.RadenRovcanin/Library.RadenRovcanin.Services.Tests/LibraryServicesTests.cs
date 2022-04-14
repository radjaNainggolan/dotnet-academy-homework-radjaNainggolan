using FluentAssertions;
using Library.RadenRovcanin.Contracts;
using Library.RadenRovcanin.Contracts.Dtos;
using Library.RadenRovcanin.Contracts.Entities;
using Library.RadenRovcanin.Contracts.Repositories;
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

            _unitOfWorkMock.Setup(m => m.Books.GetAllAsync()).ReturnsAsync(books);

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

        [Fact]
        public async Task GetBooks_WhenRepositoryNotReturnData_ThanReturnEmptyArray()
        {
            // arrange
            _unitOfWorkMock.Setup(m => m.Books.GetAllAsync()).ReturnsAsync(Array.Empty<Book>());

            // act
            var actualResult = await _sut.GetAll();

            // assert
            actualResult.Should().BeEmpty();
        }

        [Fact]
        public async Task RentBook_WhenRepositoryReturnsData_ThanMapToDto()
        {
            // arrange
            var book = BookMock.Build();
            var bookId = book.Id;
            var person = PersonMock.Build();
            var personId = person.Id;

            _unitOfWorkMock.Setup(m => m.Books.GetByIdAsync(bookId)).ReturnsAsync(book);
            _unitOfWorkMock.Setup(m => m.People.GetByIdWithBooksAsync(personId)).ReturnsAsync(person);

            // act
            await _sut.RentBook(personId, bookId);

            // assert
            _unitOfWorkMock.Verify(m => m.People.GetByIdWithBooksAsync(personId), Times.Once);
            _unitOfWorkMock.Verify(m => m.Books.GetByIdAsync(bookId), Times.Once);
            _unitOfWorkMock.Verify(m => m.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public void RentBook_WhenRepositoryCanNotFindBook_ThanThrowException()
        {
            // arrange
            const int bookId = 1;
            const int personId = 1;

            _unitOfWorkMock.Setup(m => m.Books.GetByIdAsync(bookId)).ThrowsAsync(new EntityNotFoundException());

            // act
            Action action = () => _sut.RentBook(personId, bookId).Wait();

            // assert
            action.Should().Throw<EntityNotFoundException>();
        }

        [Fact]
        public async Task ReturnBook_WhenRepositoryReturnsData_ThanMapToDto()
        {
            // arrange
            var book = BookMock.Build();
            var bookId = book.Id;
            var person = PersonMock.Build();
            person.RentedBooks.Add(book);
            var personId = person.Id;

            _unitOfWorkMock.Setup(m => m.Books.GetByIdAsync(bookId)).ReturnsAsync(book);
            _unitOfWorkMock.Setup(m => m.People.GetByIdWithBooksAsync(personId)).ReturnsAsync(person);
            // act
            await _sut.ReturnBook(personId, bookId);

            // assert
            _unitOfWorkMock.Verify(m => m.People.GetByIdWithBooksAsync(personId), Times.Once);
            _unitOfWorkMock.Verify(m => m.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public void ReturnBook_WhenRepositoryCanNotFindPerson_ThanThrowException()
        {
            // arrange

            const int bookId = 1;
            const int personId = 1;

            _unitOfWorkMock.Setup(m => m.People.GetByIdAsync(personId)).ThrowsAsync(new EntityNotFoundException());

            // act
            Action action = () => _sut.ReturnBook(personId, bookId).Wait();

            // assert
            action.Should().Throw<EntityNotFoundException>();
        }
    }
}
