using LibraryManagementSystem.Api.Models;

namespace LibraryManagementSystem.Api.Interfaces
{
    public interface IUserDataAccess
    {
        /// <summary>
        /// Validates credentials stored against database
        /// </summary>
        /// <param name="userAuthRequest">The user credential details</param>
        /// <returns>User/Null</returns>
        public User ValidateUserCredentials(UserAuthRequest userAuthRequest);
    }
}