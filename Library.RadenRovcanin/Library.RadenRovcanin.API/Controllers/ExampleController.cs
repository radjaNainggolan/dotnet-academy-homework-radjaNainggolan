using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace Library.RadenRovcanin.API.Controllers
{
    [Authorize("18plus")]
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            //var access = Request.Headers[key: HeaderNames.Authorization];
            return Ok("You are autohirized for this endpoint");
        }

        [HttpGet("Age")]
        public ActionResult GetAge()
        {
            return Ok("You are 18+ and u can access this endpoint");
        }
    }
}
