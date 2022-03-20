namespace Library.RadenRovcanin.API.Controllers
{
    using Library.RadenRovcanin.Contracts.Dtos;
    using Library.RadenRovcanin.Contracts.Entities;
    using Library.RadenRovcanin.Contracts.Services;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IPeopleService ps;

        public PeopleController(IPeopleService ps)
        {
            this.ps = ps;
        }

        [HttpGet("all")]
        public ActionResult<List<PersonDto>> Get()
        {
            List<Person> list = this.ps.GetAll();

            try
            {
                return this.Ok(list.Select(p => new PersonDto(p.Id, p.FirstName, p.LastName, p.Adress)));
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<PersonDto>> GetByCity([FromQuery] string city)
        {
            List<Person> list = this.ps.GetByCity(city);

            try
            {
                return this.Ok(list.Select(p => new PersonDto(p.Id, p.FirstName, p.LastName, p.Adress)));
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        [HttpGet("{Id}")]
        public ActionResult<PersonDto> GetById([FromRoute] string id)
        {
            Person p = this.ps.GetById(Int32.Parse(id));

            try
            {
                if (p == null)
                {
                    return this.NoContent();
                }
                else
                {
                    PersonDto pdto = new PersonDto(p.Id, p.FirstName, p.LastName, p.Adress);
                    return this.Ok(pdto);
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<PersonDto> Create([FromBody] PersonDto person)
        {
            Person newPerson = PersonDto.ToPerson(person);
            this.ps.AddPerson(newPerson);

            return this.Created(string.Empty, person);
        }
    }
}
