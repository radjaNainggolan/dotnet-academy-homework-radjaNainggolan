using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Library.RadenRovcanin.Contracts.Entities;
using Library.RadenRovcanin.Contracts.Dtos;
using Library.RadenRovcanin.Services;
using Library.RadenRovcanin.Contracts.Services;
using System.Linq;
namespace Library.RadenRovcanin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {

        public IPeopleService ps;

        public PeopleController(IPeopleService PS) 
        {
            this.ps = PS;  
        }


        [HttpGet("all")]
        public ActionResult<List<PersonDto>> Get() 
        {
            try
            {
                return Ok(ps.GetAll().Select(p => new PersonDto { Id = p.Id, FirstName = p.FirstName, LastName = p.LastName, Adress = p.Adress }));
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }

        }


        [HttpGet]
        public ActionResult<List<PersonDto>> GetByCity([FromQuery] string city)
        {
            try
            {
                return Ok(ps.GetByCity(city).Select(p => new PersonDto {Id = p.Id, FirstName = p.FirstName, LastName = p.LastName, Adress = p.Adress }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{Id}")]
        public ActionResult<PersonDto> GetById([FromRoute] string Id) 
        {

            try
            {   
                Person p = ps.GetById(Int32.Parse(Id));
                PersonDto pdo = new PersonDto 
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Adress = p.Adress
                };

                return Ok(pdo);
            }
            catch (Exception ex) 
            {
                return BadRequest();
            }
            
        }

        [HttpPost]
        public ActionResult<List<PersonDto>> Create([FromBody] PersonDto person) 
        {
            Person newPerson = new Person(person.FirstName, person.LastName, person.Adress);
            ps.AddPerson(newPerson);

            return Ok(ps.GetAll());
        }


    }
}
