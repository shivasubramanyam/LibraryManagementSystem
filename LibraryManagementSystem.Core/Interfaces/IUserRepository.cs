using LibraryManagementSystem.Core.Entities;
using LibraryManagementSystem.Core.Models;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Core.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// Validates credentials stored against database
        /// </summary>
        /// <param name="userAuthRequest">The user credential details</param>
        /// <returns>User/Null</returns>
        Task<User> ValidateUserCredentialsAsync(UserAuthRequest userAuthRequest);
    }
}