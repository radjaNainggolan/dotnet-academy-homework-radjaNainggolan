using Library.RadenRovcanin.Contracts;
using Library.RadenRovcanin.Contracts.Exceptions;
using Library.RadenRovcanin.Contracts.Requests;
using Library.RadenRovcanin.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.RadenRovcanin.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("login")]

        public async Task<IActionResult> Login([FromBody] AuthenticationRequest request)
        {
            try
            {
                var token = await _authenticationService.Login(request);
                return Ok(token);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (UserAuthenticationException ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
