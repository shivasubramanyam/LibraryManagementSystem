using LibraryManagementSystem.Api.Models;
using System.Collections.Generic;

namespace LibraryManagementSystem.Api.Interfaces
{
    public interface IBookService
    {
        /// <summary>
        /// Gets all available books from data store
        /// </summary>
        /// <returns>Collection of Books</returns>
        IEnumerable<Book> GetAllBooks();

        /// <summary>
        /// Adds a book to the data store
        /// </summary>
        /// <param name="book">The new book</param>
        /// <returns>True/False</returns>
        bool AddBook(Book book);

        /// <summary>
        /// Updates an existing book with updated details fo data store
        /// </summary>
        /// <param name="book">The updated book details</param>
        /// <returns>True/False</returns>
        bool UpdateBook(Book book);

        /// <summary>
        /// Delete an existing book from data store
        /// </summary>
        /// <param name="bookId">Id of the book to be deleted</param>
        /// <returns>True/False</returns>
        bool DeleteBookById(int bookId);

        /// <summary>
        /// adds a book to users favorite list 
        /// </summary>
        /// <param name="bookId">Id of the book to be deleted</param>
        /// <returns>True/False</returns>
        bool AddBookToFavorites(int bookId);
    }
}
