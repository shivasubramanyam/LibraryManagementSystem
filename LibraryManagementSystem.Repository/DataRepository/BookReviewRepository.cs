using Dapper;
using LibraryManagementSystem.Core.Constants;
using LibraryManagementSystem.Core.Entities;
using LibraryManagementSystem.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Repository.DataRepository
{
    public class BookReviewRepository : IBookReviewRepository
    {
        private readonly IDapper _dapper;

        public BookReviewRepository(IDapper dapper)
        {
            _dapper = dapper;
        }

        public async Task<IEnumerable<BookReview>> GetAllReviewsForABook(int bookId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@BookId", bookId);
            return await _dapper.GetAllAsync<BookReview>(StoredProc.GetAllReviews, parameters);
        }

        public async Task<bool> InsertReviewAsync(BookReviewRequest bookReview)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@BookId", bookReview.BookId);
            parameters.Add("@UserId", bookReview.UserId);
            parameters.Add("@Review", bookReview.Review);
            parameters.Add("@CreatedDateTime", bookReview.CreatedDateTime);
            var createdCount = await _dapper.ExecuteAsync(StoredProc.InsertReview, parameters);

            return createdCount > 0;
        }
    }
}
