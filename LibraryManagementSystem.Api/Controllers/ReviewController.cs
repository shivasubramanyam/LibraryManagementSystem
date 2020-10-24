using LibraryManagementSystem.Api.CustomAttributes;
using LibraryManagementSystem.Core.Constants;
using LibraryManagementSystem.Core.Entities;
using LibraryManagementSystem.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : BaseController
    {
        private readonly IBookReviewService _bookReviewService;

        public ReviewController(IBookReviewService bookReviewService)
        {
            _bookReviewService = bookReviewService;
        }

        [HttpGet]
        [AuthorizeRoles(roles: Role.Admin)]
        public async Task<IActionResult> GetBookReviewsAsync(int bookId)
        {
            try
            {
                var reviews = await _bookReviewService.GetAllReviewsForABook(bookId);
                if (reviews.Any())
                    return Ok(reviews);
            }
            catch (Exception ex)
            {
                //Log exception here
                return BadRequest("OOPS! Something went wrong while processing your request. Please try again");
            }

            return NoContent();
        }

        [HttpPost]
        [AuthorizeRoles(roles: Role.User)]
        public async Task<IActionResult> AddReviewAsync(BookReviewRequest bookReview)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(bookReview?.Review))
                    return BadRequest("Review cannot be null or empty");

                bookReview.UserId = UserId;
                var isReviewAdded = await _bookReviewService.InsertReviewAsync(bookReview);
                if (isReviewAdded)
                    return Created(nameof(AddReviewAsync), bookReview);
            }
            catch (Exception ex)
            {
                //Log exception here
                return BadRequest("OOPS! Something went wrong while processing your request. Please try again");
            }

            return BadRequest("Either book does not exist/you cannot edit a review once submitted");
        }
    }
}