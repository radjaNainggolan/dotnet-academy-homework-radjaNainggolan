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
        public async Task<ActionResult<IList<PersonDtoResponse>>> Get()
        {
            var list = await peopleService.GetAll();
            return Ok(list);
        }

        [HttpGet]
        public async Task<ActionResult<IList<PersonDtoResponse>>> GetByCity([FromQuery] string city)
        {
            var list = await peopleService.GetByCity(city);
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDtoResponse>> GetById([FromRoute] int id)
        {
            var personDtoResponse = await peopleService.GetById(id);
            return Ok(personDtoResponse);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] PersonDtoRequest person)
        {
            await peopleService.AddPerson(person);
            return Created("Person is successfully created", null);
        }
    }
}
