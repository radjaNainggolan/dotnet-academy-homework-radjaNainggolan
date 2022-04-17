using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.RadenRovcanin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public ActionResult Get()
        {
            // var access = Request.Headers[key: HeaderNames.Authorization];
            return Ok("You are autohirized for this endpoint");
        }

        [Authorize(Policy = "18plus")]
        [HttpGet("Age")]
        public ActionResult GetAge()
        {
            // var age = HttpContext.User.Claims.First(claim => claim.Type == "Age").Value;
            return Ok("You are 18+ and u can access this endpoint");
        }
    }
}
