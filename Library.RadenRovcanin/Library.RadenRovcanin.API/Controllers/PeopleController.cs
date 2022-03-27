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
        public ActionResult<List<PersonDtoResponse>> Get()
        {
            var list = peopleService.GetAll();
            return Ok(list);
        }

        [HttpGet]
        public ActionResult<List<PersonDtoResponse>> GetByCity([FromQuery] string city)
        {
            var list = peopleService.GetByCity(city);
            return Ok(list);
        }

        [HttpGet("{id}")]
        public ActionResult<PersonDtoResponse> GetById([FromRoute] int id)
        {
            var personDtoResponse =  peopleService.GetById(id);
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
