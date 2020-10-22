using LibraryManagementSystem.Api.Models;
using System.Collections.Generic;

namespace LibraryManagementSystem.Api.Interfaces
{
    public interface IBookDataStore
    {
        /// <summary>
        /// Gets all available books from data store
        /// </summary>
        /// <returns>Collection of Books</returns>
        IEnumerable<Book> RetrieveAllBooks();

        /// <summary>
        /// Gets the book from data store
        /// </summary>
        /// <returns>A Book</returns>
        IEnumerable<Book> GetBookById(int bookId);

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
        bool DeleteBook(int bookId);

        /// <summary>
        /// adds a book to users favorite list 
        /// </summary>
        /// <param name="bookId">Id of the book to be deleted</param>
        /// <returns>True/False</returns>
        bool AddToFavorites(int bookId);

        /// <summary>
        /// Updates the given book as read for the user 
        /// </summary>
        /// <param name="bookId">Id of the book to be deleted</param>
        /// <returns>True/False</returns>
        bool MarkBookAsRead(int bookId);
    }
}
