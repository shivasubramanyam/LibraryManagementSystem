using Dapper;
using LibraryManagementSystem.Core.Constants;
using LibraryManagementSystem.Core.Entities;
using LibraryManagementSystem.Core.Interfaces;
using LibraryManagementSystem.Core.Models;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Repository.DataRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDapper _dapper;

        public UserRepository(IDapper dapper)
        {
            _dapper = dapper;
        }

        public async Task<User> ValidateUserCredentialsAsync(UserAuthRequest userAuthRequest)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserName", userAuthRequest.UserName);
            parameters.Add("@Password", userAuthRequest.Password);
            var user = await _dapper.GetAsync<User>(StoredProc.GetUserByLoginCredential, parameters);

            return user;
        }
    }
}
