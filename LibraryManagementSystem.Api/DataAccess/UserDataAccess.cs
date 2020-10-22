using LibraryManagementSystem.Api.Interfaces;
using LibraryManagementSystem.Api.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem.Api.DataAccess
{
    public class UserDataAccess : IUserDataAccess
    {
        private readonly List<User> _users;

        public UserDataAccess(IConfiguration configuration)
        {
            _users = configuration.GetSection("users").Get<List<User>>();
        }

        public User ValidateUserCredentials(UserAuthRequest userAuthRequest)
        {
            var isAuthorizedUser =  _users.Any(u =>
                u.UserName.Equals(userAuthRequest.UserName, StringComparison.OrdinalIgnoreCase) &&
                u.Password.Equals(userAuthRequest.Password, StringComparison.OrdinalIgnoreCase));
            if (!isAuthorizedUser)
                return null;

            return _users.Single(u =>
                u.UserName.Equals(userAuthRequest.UserName, StringComparison.OrdinalIgnoreCase) &&
                u.Password.Equals(userAuthRequest.Password, StringComparison.OrdinalIgnoreCase));
        }
    }
}
