using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskAndTeamManagement.Application.Dtos.Auth.Login;
using TaskAndTeamManagement.Application.Dtos.Auth.Registration;
using TaskAndTeamManagement.Application.IService.Authentication;
using IAuthenticationService = TaskAndTeamManagement.Application.IService.Authentication.IAuthenticationService;

namespace TaskAndTeamManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDto userRegistrationDto)
        {
            var result = await _authenticationService.UserRegistrationAsync(userRegistrationDto);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var result = await _authenticationService.UserLoginAsync(loginRequestDto);
            return Ok(result);
        }
    }
}
