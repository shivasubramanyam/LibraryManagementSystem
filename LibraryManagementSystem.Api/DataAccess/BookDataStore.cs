using LibraryManagementSystem.Api.Interfaces;
using LibraryManagementSystem.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Api.DataAccess
{
    public class BookDataStore : IBookDataStore
    {
        public BookDataStore()
        {

        }

        public bool AddBook(Book book)
        {
            throw new NotImplementedException();
        }

        public bool AddToFavorites(int bookId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteBook(int bookId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetBookById(int bookId)
        {
            throw new NotImplementedException();
        }

        public bool MarkBookAsRead(int bookId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> RetrieveAllBooks()
        {
            throw new NotImplementedException();
        }

        public bool UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
