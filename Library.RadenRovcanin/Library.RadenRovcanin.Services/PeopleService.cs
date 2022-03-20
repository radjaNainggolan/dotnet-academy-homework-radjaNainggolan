using Library.RadenRovcanin.Contracts.Entities;
using Library.RadenRovcanin.Contracts.Services;

namespace Library.RadenRovcanin.Services
{
    public class PeopleService : IPeopleService
    {
        private List<Person> people = new List<Person>
        {
            new Person("Raden", "Rovcanin",  new Adress { Street = "Ostroska 7.", City = "Pljevlja", Country = "Crna Gora" }),
            new Person("Damir", "Delijic",  new Adress { Street = "Profesorska 17.", City = "Podgorica", Country = "Crna Gora" }),
            new Person("Rade", "Veljic",  new Adress { Street = "Blaza Jovanovica 13.", City = "Spuz", Country = "Crna Gora" }),
        };

        public PeopleService() { }

        public List<Person> GetAll()
        {
            return this.people;
        }

        public Person GetById(int Id)
        {
            Person p = this.people.Find(x => x.Id == Id);
            return p;
        }

        public List<Person> GetByCity(string city)
        {
            return this.people.Where(x => x.Adress.City.Equals(city, StringComparison.CurrentCultureIgnoreCase)).ToList();
        }

        public void AddPerson(Person p)
        {
            this.people.Add(p);
        }
    }
}