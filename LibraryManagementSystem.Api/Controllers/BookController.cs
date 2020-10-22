using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.Api.Constants;
using LibraryManagementSystem.Api.CustomAttributes;
using LibraryManagementSystem.Api.Interfaces;
using LibraryManagementSystem.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [AuthorizeRoles(Role.Admin, Role.User)]
        public IActionResult ListAllBooks()
        {
            var books = _bookService.GetAllBooks();
            if (books != null && books.Any())
                return Ok(books);

            return NoContent();
        }

        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public IActionResult AddNewBook(Book book)
        {
            var isBookAdded = _bookService.AddBook(book);
            if (isBookAdded)
                return CreatedAtAction(nameof(AddNewBook), book);

            return BadRequest("Failed to add book to the store");
        }

        [HttpPut]
        [Authorize(Roles = Role.Admin)]
        public IActionResult UpdateBook(Book book)
        {
            var isBookUpdated = _bookService.UpdateBook(book);
            if (isBookUpdated)
                return Ok("Book details were updated successfully to the store");

            return BadRequest("Failed to update book details to the store");
        }

        [HttpPut]
        [Authorize(Roles = Role.Admin)]
        public IActionResult DeleteBook(int bookId)
        {
            var isBookDeleted = _bookService.DeleteBookById(bookId);
            if (isBookDeleted)
                return Ok($"Book with id '{bookId}' has been deleted");

            return BadRequest($"Failed to delete book with id '{bookId}");
        }
    }
}