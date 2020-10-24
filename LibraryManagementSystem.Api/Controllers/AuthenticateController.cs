using LibraryManagementSystem.Core.Interfaces;
using LibraryManagementSystem.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
        public async Task<IActionResult> LoginAsync([FromBody] UserAuthRequest userAuthRequest)
        {
            IActionResult response = Unauthorized();
            try
            {
                var jwtToken = await _authenticationService.AuthenticateUserAsync(userAuthRequest);
                if (!string.IsNullOrEmpty(jwtToken))
                    return Ok(new { token = jwtToken });
            }
            catch (Exception ex)
            {
                //Log exception here
                return BadRequest("OOPS! Something went wrong while processing your request. Please try again");
            }

            return response;
        }
    }
}