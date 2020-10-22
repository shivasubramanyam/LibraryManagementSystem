using LibraryManagementSystem.Api.Models;

namespace LibraryManagementSystem.Api.Interfaces
{
    public interface IAuthenticationService
    {
        /// <summary>
        /// Authenticates user by validation the provided credentials
        /// </summary>
        /// <param name="authRequest">The user authentication data</param>
        /// <returns>Null/Token if credentials are valid</returns>
        string AuthenticateUser(UserAuthRequest authRequest);
    }
}