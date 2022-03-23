using Library.RadenRovcanin.Contracts.Dtos;
using Library.RadenRovcanin.Contracts.Entities;
using Library.RadenRovcanin.Contracts.Services;

namespace Library.RadenRovcanin.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly List<Person> people = new()
        {
            new Person("Raden", "Rovcanin", new Adress { Street = "Ostroska 7.", City = "Pljevlja", Country = "Crna Gora" }),
            new Person("Damir", "Delijic", new Adress { Street = "Profesorska 17.", City = "Podgorica", Country = "Crna Gora" }),
            new Person("Rade", "Veljic", new Adress { Street = "Blaza Jovanovica 13.", City = "Spuz", Country = "Crna Gora" }),
        };

        public List<PersonDto>? GetAll()
        {
            return people.Count > 0 ? people.ConvertAll(p => new PersonDto(p.Id, p.FirstName, p.LastName, p.Adress)) : null;
        }

        public PersonDto? GetById(int id)
        {
            PersonDto? personDto = people.Where(x => x.Id == id)
                .Select(x => new PersonDto(x.Id, x.FirstName, x.LastName, x.Adress))
                .FirstOrDefault();

            return personDto ?? null;
        }

        public List<PersonDto>? GetByCity(string city)
        {
            List<PersonDto> list = people.Where(x => x.Adress.City.Equals(city, StringComparison.CurrentCultureIgnoreCase))
                .Select(x => new PersonDto(x.Id, x.FirstName, x.LastName, x.Adress)).ToList();
            return list.Count > 0 ? list : null;
        }

        public void AddPerson(PersonDto personDto)
        {
            people.Add(PersonDto.ToPerson(personDto));
        }
    }
}
