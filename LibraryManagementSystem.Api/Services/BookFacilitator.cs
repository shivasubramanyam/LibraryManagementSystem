using System.Threading.Tasks;
using LibraryManagementSystem.Core.Interfaces;

namespace LibraryManagementSystem.Api.Services
{
    public class BookFacilitator : IBookFacilitator
    {
        private readonly IBookRepository _bookDataStore;

        public BookFacilitator(IBookRepository bookDataStore)
        {
            _bookDataStore = bookDataStore;
        }

        public async Task<bool> AddBookToFavoritesAsync(int userId, int bookId)
        {
            return await _bookDataStore.AddToFavoritesAsync(userId, bookId);
        }

        public async Task<bool> MarkBookAsReadAsync(int userId, int bookId)
        {
            return await _bookDataStore.UpdateBookAsReadAsync(userId, bookId);
        }
    }
}
