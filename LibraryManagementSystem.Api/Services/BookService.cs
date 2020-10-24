using LibraryManagementSystem.Core.Entities;
using LibraryManagementSystem.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Api.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookDataStore;

        public BookService(IBookRepository bookDataStore)
        {
            _bookDataStore = bookDataStore;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _bookDataStore.RetrieveAllBooksAsync();
        }

        public async Task<bool> AddBookAsync(Book book)
        {
            return await _bookDataStore.AddBookAsync(book);
        }

        public async Task<bool> UpdateBookAsync(Book book)
        {
            return await _bookDataStore.UpdateBookAsync(book);
        }

        public async Task<bool> DeleteBookByIdAsync(int bookId)
        {
            return await _bookDataStore.DeleteBookAsync(bookId);
        }
    }
}
