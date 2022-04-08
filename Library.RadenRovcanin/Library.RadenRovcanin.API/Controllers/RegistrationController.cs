using Library.RadenRovcanin.Contracts.Exceptions;
using Library.RadenRovcanin.Contracts.Requests;
using Library.RadenRovcanin.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.RadenRovcanin.API.Controllers
{
    [AllowAnonymous]
    [Route("api/")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpPost]
        [Route("registration")]

        public async Task<IActionResult> Register([FromBody] RegistrationRequest request)
        {
            try
            {
                await _registrationService.Register(request);
                return Ok();
            }
            catch (EntityAlreadyExistsException ex)
            {
                return Conflict(ex.Message);
            }
            catch (UserRegistrationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
