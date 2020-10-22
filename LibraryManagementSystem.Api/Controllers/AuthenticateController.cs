using LibraryManagementSystem.Api.Interfaces;
using LibraryManagementSystem.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticateController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [AllowAnonymous]
        [Route("")]
        [HttpPost]
        public IActionResult Login([FromBody] UserAuthRequest userAuthRequest)
        {
            IActionResult response = Unauthorized();
            var jwtToken = _authenticationService.AuthenticateUser(userAuthRequest);
            if (string.IsNullOrEmpty(jwtToken))
                return response;

            return Ok(new { token = jwtToken });
        }
    }
}