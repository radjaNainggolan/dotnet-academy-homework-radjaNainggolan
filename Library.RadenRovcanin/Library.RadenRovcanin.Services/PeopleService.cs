using Library.RadenRovcanin.Contracts.Dtos;
using Library.RadenRovcanin.Contracts.Entities;
using Library.RadenRovcanin.Contracts.Services;

namespace Library.RadenRovcanin.Services
{
    public class PeopleService : IPeopleService
    {
        private static int autoId = 0;

        private readonly List<Person> people = new()
        {
            new Person(autoId++, "Raden", "Rovcanin", new Address("Ostroska 7.", "Pljevlja", "Crna Gora")),
            new Person(autoId++, "Damir", "Delijic", new Address("Profesorska 17.", "Podgorica", "Crna Gora")),
            new Person(autoId++, "Rade", "Veljic", new Address("Blaza Jovanovica 13.", "Spuz", "Crna Gora")),
        };

        public List<PersonDto> GetAll()
        {
            return people.ConvertAll(p => new PersonDto(
                p.Id,
                p.FirstName,
                p.LastName,
                new AddressDto(
                    p.Address.Street,
                    p.Address.City,
                    p.Address.Country)));
        }

        public PersonDto? GetById(int id)
        {
            PersonDto? personDto = people
                .Where(x => x.Id == id)
                .Select(x => new PersonDto(
                    x.Id,
                    x.FirstName,
                    x.LastName,
                    new AddressDto(
                        x.Address.Street,
                        x.Address.City,
                        x.Address.Country)))
                .FirstOrDefault();

            return personDto;
        }

        public List<PersonDto> GetByCity(string city)
        {
            List<PersonDto> list = people
                .Where(x => x.Address.City.Equals(city, StringComparison.CurrentCultureIgnoreCase))
                .Select(x => new PersonDto(
                    x.Id,
                    x.FirstName,
                    x.LastName,
                    new AddressDto(x.Address.Street, x.Address.City, x.Address.Country)))
                .ToList();
            return list;
        }

        public void AddPerson(PersonDto personDto)
        {
            people.Add(new Person(
                autoId++,
                personDto.FirstName,
                personDto.LastName,
                new Address(
                    personDto.Address.Street,
                    personDto.Address.City,
                    personDto.Address.Country)));
        }
    }
}
