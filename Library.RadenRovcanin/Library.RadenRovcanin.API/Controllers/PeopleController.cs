using Library.RadenRovcanin.Contracts.Dtos;
using Library.RadenRovcanin.Contracts.Services;
using Library.RadenRovcanin.Services;
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
        public ActionResult<PersonDtoRequest> Create([FromBody] PersonDtoRequest person)
        {
            peopleService.AddPerson(person);
            return this.Created("Person is successfully created", null);
        }
    }
}
