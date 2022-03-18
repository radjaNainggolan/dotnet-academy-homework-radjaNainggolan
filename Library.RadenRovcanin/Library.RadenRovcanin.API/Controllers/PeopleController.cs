using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Library.RadenRovcanin.Contracts.Entities;
using Library.RadenRovcanin.Contracts.Dtos;

namespace Library.RadenRovcanin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {

        public PeopleController() {}

        [HttpGet("/all")]
        public IActionResult Get() 
        { 
              
            return Ok();
        }


        [HttpGet]
        public IActionResult GetByCity([FromQuery] string city)
        {

            return Ok();
        }


        [HttpGet("{id}")]
        public IActionResult GetByID([FromRoute] string personID) 
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Create(PersonDto person) 
        {
            return Ok();
        }


    }
}
