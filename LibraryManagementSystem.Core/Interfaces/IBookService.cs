using LibraryManagementSystem.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Core.Interfaces
{
    public interface IBookService
    {
        /// <summary>
        /// Gets all available books from data store
        /// </summary>
        /// <returns>Collection of Books</returns>
        Task<IEnumerable<Book>> GetAllBooksAsync();

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
        Task<bool> DeleteBookByIdAsync(int bookId);
    }
}
