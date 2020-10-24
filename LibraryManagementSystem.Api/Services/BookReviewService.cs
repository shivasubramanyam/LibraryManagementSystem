using LibraryManagementSystem.Core.Entities;
using LibraryManagementSystem.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Api.Services
{
    public class BookReviewService : IBookReviewService
    {
        private readonly IBookReviewRepository _bookReviewRepository;

        public BookReviewService(IBookReviewRepository bookReviewRepository)
        {
            _bookReviewRepository = bookReviewRepository;
        }

        public async Task<IEnumerable<BookReview>> GetAllReviewsForABook(int bookId)
        {
            return await _bookReviewRepository.GetAllReviewsForABook(bookId);
        }

        public async Task<bool> InsertReviewAsync(BookReviewRequest bookReview)
        {
            return await _bookReviewRepository.InsertReviewAsync(bookReview);
        }
    }
}
