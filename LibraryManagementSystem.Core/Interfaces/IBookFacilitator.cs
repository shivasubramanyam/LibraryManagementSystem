using System.Threading.Tasks;

namespace LibraryManagementSystem.Core.Interfaces
{
    public interface IBookFacilitator
    {
        /// <summary>
        /// adds a book to users favorite list 
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <param name="bookId">Id of the book to be added as favorite</param>
        /// <returns>True/False</returns>
        Task<bool> AddBookToFavoritesAsync(int userId, int bookId);

        /// <summary>
        /// adds a book to users favorite list 
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <param name="bookId">Id of the book to be marked as read</param>
        /// <returns>True/False</returns>
        Task<bool> MarkBookAsReadAsync(int userId, int bookId);
    }
}
