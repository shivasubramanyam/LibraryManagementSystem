using Dapper;
using LibraryManagementSystem.Core.Constants;
using LibraryManagementSystem.Core.Entities;
using LibraryManagementSystem.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Repository.DataRepository
{
    public class BookRepository : IBookRepository
    {
        private readonly IDapper _dapper;

        public BookRepository(IDapper dapper)
        {
            _dapper = dapper;
        }

        public async Task<Book> GetBookByIdAsync(int bookId)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@BookId", bookId);

            return await _dapper.GetAsync<Book>(StoredProc.GetBookById, parameter);
        }

        public async Task<IEnumerable<Book>> RetrieveAllBooksAsync()
        {
            return await _dapper.GetAllAsync<Book>(StoredProc.GetAllBooks, null);
        }

        public async Task<bool> AddBookAsync(Book book)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Title", book.Title);
            parameters.Add("@Description", book.Description);
            parameters.Add("@AuthorName", book.Author);
            parameters.Add("@PublishedYear", book.PublishedYear);
            var result = await _dapper.ExecuteAsync(StoredProc.InsertBook, parameters);

            return result > 0;
        }

        public async Task<bool> UpdateBookAsync(Book book)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@BookId", book.BookId);
            parameters.Add("@Title", book.Title);
            parameters.Add("@Description", book.Description);
            parameters.Add("@AuthorName", book.Author);
            parameters.Add("@PublishedYear", book.PublishedYear);
            var result = await _dapper.ExecuteAsync(StoredProc.UpdateBook, parameters);

            return result > 0;
        }

        public async Task<bool> DeleteBookAsync(int bookId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@BookId", bookId);
            var deletedCount = await _dapper.ExecuteAsync(StoredProc.DeleteBook, parameters);

            return deletedCount > 0;
        }

        public async Task<bool> AddToFavoritesAsync(int userId, int bookId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@BookId", bookId);
            parameters.Add("@UserId", userId);
            var result = await _dapper.ExecuteAsync(StoredProc.MarkBookAsUserFavorite, parameters);

            return result > 0;
        }

        public async Task<bool> UpdateBookAsReadAsync(int userId, int bookId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@BookId", bookId);
            parameters.Add("@UserId", userId);
            var updatedCount = await _dapper.ExecuteAsync(StoredProc.MarkBookAsReadByUser, parameters);

            return updatedCount > 0;
        }
    }
}
