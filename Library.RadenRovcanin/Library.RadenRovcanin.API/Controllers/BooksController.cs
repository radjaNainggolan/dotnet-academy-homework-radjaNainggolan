using Library.RadenRovcanin.Contracts.Dtos;
using Library.RadenRovcanin.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.RadenRovcanin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ILibraryService _iLibraryService;

        public BooksController(ILibraryService iLibraryService)
        {
            _iLibraryService = iLibraryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAll()
        {
            var books = await _iLibraryService.GetAll();
            return Ok(books);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> RentBook([FromRoute] int id)
        {
            var currentUserId = CurrentUser();
            await _iLibraryService.RentBook(currentUserId, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> ReturnBook([FromRoute] int id)
        {
            var currentUserId = CurrentUser();
            await _iLibraryService.ReturnBook(currentUserId, id);
            return NoContent();
        }

        [HttpGet("me")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<BookDto>>> RentedBooks()
        {
            var currentUserId = CurrentUser();
            var rentedBooks = await _iLibraryService.RentedBooks(currentUserId);
            return Ok(rentedBooks);
        }

        private int CurrentUser()
        {
            var id = this.User.Claims.First(claim => claim.Type == "Id").Value;
            return int.Parse(id);
        }
    }
}
