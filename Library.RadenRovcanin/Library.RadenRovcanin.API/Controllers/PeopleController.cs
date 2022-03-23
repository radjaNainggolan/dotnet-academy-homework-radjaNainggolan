using Library.RadenRovcanin.Contracts.Dtos;
using Library.RadenRovcanin.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
namespace Library.RadenRovcanin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService peopleService;

        public PeopleController(IPeopleService iPeopleService)
        {
            this.peopleService = iPeopleService;
        }

        [HttpGet("all")]
        public ActionResult<List<PersonDto>> Get()
        {
            List<PersonDto>? list = peopleService.GetAll();

            try
            {
                return Ok(list);
            }
            catch (Exception)
            {
                return NoContent();
            }
        }

        [HttpGet]
        public ActionResult<List<PersonDto>> GetByCity([FromQuery] string city)
        {
            List<PersonDto>? list = peopleService.GetByCity(city);
            try
            {
                return Ok(list);
            }
            catch (Exception)
            {
                return NoContent();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<PersonDto> GetById([FromRoute] string id)
        {
            PersonDto? personDto = peopleService.GetById(int.Parse(id));

            try
            {
                return Ok(personDto);
            }
            catch (Exception)
            {
                return NoContent();
            }
        }

        [HttpPost]
        public ActionResult<PersonDto> Create([FromBody] PersonDto person)
        {
            peopleService.AddPerson(person);
            return this.Created(string.Empty, person);
        }
    }
}
