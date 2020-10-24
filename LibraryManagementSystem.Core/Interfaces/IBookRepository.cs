using LibraryManagementSystem.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Core.Interfaces
{
    public interface IBookRepository
    {
        /// <summary>
        /// Gets all available books from data store
        /// </summary>
        /// <returns>Collection of Books</returns>
        Task<IEnumerable<Book>> RetrieveAllBooksAsync();

        /// <summary>
        /// Gets the book from data store
        /// </summary>
        /// <returns>A Book</returns>
        Task<Book> GetBookByIdAsync(int bookId);

        /// <summary>
        /// Adds a book to the data store
        /// </summary>
        /// <param name="book">The new book</param>
        /// <returns>True/False</returns>
        Task<bool> AddBookAsync(Book book);

        /// <summary>
        /// Updates an existing book with updated details fo data store
        /// </summary>
        /// <param name="book">The updated book details</param>
        /// <returns>True/False</returns>
        Task<bool> UpdateBookAsync(Book book);

        /// <summary>
        /// Delete an existing book from data store
        /// </summary>
        /// <param name="bookId">Id of the book to be deleted</param>
        /// <returns>True/False</returns>
        Task<bool> DeleteBookAsync(int bookId);

        /// <summary>
        /// adds a book to users favorite list 
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <param name="bookId">Id of the book to be added as favorite</param>
        /// <returns>True/False</returns>
        Task<bool> AddToFavoritesAsync(int userId, int bookId);

        /// <summary>
        /// Updates the given book as read for the user 
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <param name="bookId">Id of the book to be updated as read</param>
        /// <returns>True/False</returns>
        Task<bool> UpdateBookAsReadAsync(int userId, int bookId);
    }
}
