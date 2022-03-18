using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Library.RadenRovcanin.Contracts.Entities;
using Library.RadenRovcanin.Contracts.Dtos;
using Library.RadenRovcanin.Contracts.Services;
namespace Library.RadenRovcanin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        
        PersonService ps = new PersonService();

        public PeopleController() 
        {
            
        }

        [HttpGet("all")]
        public ActionResult<List<Person>> Get() 
        {

            try
            {
                return Ok(ps.GetAll());
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }

            
            
        }


        [HttpGet]
        public ActionResult<List<Person>> GetByCity([FromQuery] string city)
        {
            try
            {

                return Ok(ps.GetByCity(city));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public ActionResult<Person> GetById([FromRoute] string personID) 
        {

            try
            {
                Person p = ps.GetById(Int32.Parse(personID));
                return Ok(p);
            }
            catch (Exception ex) 
            {
                return NotFound(ex);
            }
            
        }

        [HttpPost]
        public IActionResult Create(PersonDto pd) 
        {
            return Ok();
        }


    }
}
