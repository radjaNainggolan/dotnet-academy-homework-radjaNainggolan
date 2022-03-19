using Library.RadenRovcanin.Contracts.Dtos;
using Library.RadenRovcanin.Contracts.Entities;
using Library.RadenRovcanin.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
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
            List<Person> list = ps.GetAll();

            try
            {
                return Ok(list.Select(p => new PersonDto(p.Id, p.FirstName, p.LastName, p.Adress)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet]
        public ActionResult<List<PersonDto>> GetByCity([FromQuery] string city)
        {
            List<Person> list = ps.GetByCity(city);

            try
            {
                return Ok(list.Select(p => new PersonDto(p.Id, p.FirstName, p.LastName, p.Adress)));
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
                PersonDto pdto = new PersonDto(p.Id, p.FirstName, p.LastName, p.Adress);
                return Ok(pdto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public ActionResult<List<PersonDto>> Create([FromBody] PersonDto person)
        {
            Person newPerson = PersonDto.toPerson(person);
            ps.AddPerson(newPerson);

            return Created("", person);
        }


    }
}
