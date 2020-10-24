using System;
using LibraryManagementSystem.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using LibraryManagementSystem.Api.CustomAttributes;
using LibraryManagementSystem.Core.Constants;

namespace LibraryManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [AuthorizeRoles(roles: Role.User)]
    [ApiController]
    public class BookServiceController : BaseController
    {
        private readonly IBookFacilitator _bookFacilitator;

        public BookServiceController(IBookFacilitator bookFacilitator)
        {
            _bookFacilitator = bookFacilitator;
        }

        [HttpPost]
        public async Task<IActionResult> AddToFavoritesAsync(int bookId)
        {
            try
            {
                var isBookAddedToFavorite = await _bookFacilitator.AddBookToFavoritesAsync(UserId, bookId);
                if (isBookAddedToFavorite)
                    return Ok($"Book with id '{bookId}' has been added to your favorites");
            }
            catch (Exception ex)
            {
                //Log exception here
                return BadRequest("OOPS! Something went wrong while processing your request. Please try again");
            }

            return BadRequest($"Failed to add book with id '{bookId}' to your favorites");
        }

        [HttpPut]
        [Route("MarkAsRead")]
        public async Task<IActionResult> MarkBookAsReadAsync(int bookId)
        {
            try
            {
                var isBookUpdated = await _bookFacilitator.MarkBookAsReadAsync(UserId, bookId);
                if (isBookUpdated)
                    return Ok($"Book with id '{bookId}' has been marked as read");
            }
            catch (Exception ex)
            {
                //Log exception here
                return BadRequest("OOPS! Something went wrong while processing your request. Please try again");
            }

            return NotFound($"Book with id '{bookId}' is not found in your favorite list");
        }
    }
}