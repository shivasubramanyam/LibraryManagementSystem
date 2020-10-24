using LibraryManagementSystem.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Core.Interfaces
{
    public interface IBookReviewService
    {
        Task<IEnumerable<BookReview>> GetAllReviewsForABook(int bookId);
        Task<bool> InsertReviewAsync(BookReviewRequest bookReview);
    }
}
