using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace LibraryManagementSystem.Api.CustomAttributes
{
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public AuthorizeRolesAttribute(params string[] roles) : base()
        {
            if (roles.Any())
                Roles = string.Join(",", roles);
        }
    }
}
