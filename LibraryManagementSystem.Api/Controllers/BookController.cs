using LibraryManagementSystem.Api.CustomAttributes;
using LibraryManagementSystem.Core.Constants;
using LibraryManagementSystem.Core.Entities;
using LibraryManagementSystem.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : BaseController
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [AuthorizeRoles(Role.Admin, Role.User)]
        public async Task<IActionResult> ListAllBooksAsync()
        {
            var books = await _bookService.GetAllBooksAsync();
            if (books != null && books.Any())
                return Ok(books);

            return NoContent();
        }

        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> AddNewBookAsync(Book book)
        {
            var isBookAdded = await _bookService.AddBookAsync(book);
            if (isBookAdded)
                return Created(nameof(AddNewBookAsync), book);

            return BadRequest("Failed to add book to the store");
        }

        [HttpPut]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> UpdateBookAsync(Book book)
        {
            var isBookUpdated = await _bookService.UpdateBookAsync(book);
            if (isBookUpdated)
                return Ok("Book details were updated successfully to the store");

            return BadRequest("Failed to update book details to the store");
        }

        [HttpDelete]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> DeleteBookAsync(int bookId)
        {
            var isBookDeleted = await _bookService.DeleteBookByIdAsync(bookId);
            if (isBookDeleted)
                return Ok($"Book with id '{bookId}' has been deleted");

            return BadRequest($"Failed to delete book with id '{bookId}");
        }
    }
}