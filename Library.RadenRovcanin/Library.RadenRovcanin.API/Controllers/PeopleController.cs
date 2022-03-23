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
            return Ok(list);
        }

        [HttpGet]
        public ActionResult<List<PersonDto>> GetByCity([FromQuery] string city)
        {
            List<PersonDto>? list = peopleService.GetByCity(city);
            return Ok(list);
        }

        [HttpGet("{id}")]
        public ActionResult<PersonDto> GetById([FromRoute] int id)
        {
            PersonDto? personDto = peopleService.GetById(id);
            return Ok(personDto);
        }

        [HttpPost]
        public ActionResult<PersonDto> Create([FromBody] PersonDto person)
        {
            peopleService.AddPerson(person);
            return this.Created(string.Empty, person);
        }
    }
}
