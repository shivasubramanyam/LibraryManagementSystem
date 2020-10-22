using LibraryManagementSystem.Api.Interfaces;
using LibraryManagementSystem.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Api.Services
{
    public class BookService : IBookService
    {
        private readonly IBookDataStore _bookDataStore;

        public BookService(IBookDataStore bookDataStore)
        {
            _bookDataStore = bookDataStore;
        }

        public bool AddBook(Book book)
        {
            return _bookDataStore.AddBook(book);
        }

        public bool AddBookToFavorites(int bookId)
        {
            return _bookDataStore.AddToFavorites(bookId);
        }

        public bool DeleteBookById(int bookId)
        {
            return _bookDataStore.DeleteBook(bookId);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _bookDataStore.RetrieveAllBooks();
        }

        public bool UpdateBook(Book book)
        {
            return _bookDataStore.UpdateBook(book);
        }
    }
}
