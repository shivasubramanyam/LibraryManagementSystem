using LibraryManagementSystem.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Core.Interfaces
{
    public interface IBookReviewRepository
    {
        Task<IEnumerable<BookReview>> GetAllReviewsForABook(int bookId);
        Task<bool> InsertReviewAsync(BookReviewRequest bookReview);
    }
}
