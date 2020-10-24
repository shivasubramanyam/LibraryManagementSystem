using LibraryManagementSystem.Core.Models;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Core.Interfaces
{
    public interface IAuthenticationService
    {
        /// <summary>
        /// Authenticates user by validation the provided credentials
        /// </summary>
        /// <param name="authRequest">The user authentication data</param>
        /// <returns>Null/Token if credentials are valid</returns>
        Task<string> AuthenticateUserAsync(UserAuthRequest authRequest);
    }
}