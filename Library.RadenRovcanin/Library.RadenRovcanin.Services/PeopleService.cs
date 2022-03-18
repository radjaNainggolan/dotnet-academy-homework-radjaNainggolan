using Library.RadenRovcanin.Contracts.Entities;
using Library.RadenRovcanin.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Library.RadenRovcanin.Services
{
    public class PeopleService : IPeopleService
    {

        public List<Person> people = new List<Person>
        {

            new Person("Raden","Rovcanin",  new Adress{Street = "Ostroska 7.", City = "Pljevlja",Country = "Crna Gora"}),
            new Person("Damir","Delijic",  new Adress{Street = "Profesorska 17.", City = "Podgorica",Country = "Crna Gora"}),
            new Person("Rade","Veljic",  new Adress{Street = "Blaza Jovanovica 13.", City = "Spuz",Country = "Crna Gora"})


        };

        public PeopleService() { }

        public List<Person> GetAll()
        {
            return people;

        }

        public Person GetById(int Id)
        {
            Person p = people.Find(x => x.Id == Id);
            return p;

        }

        public List<Person> GetByCity(string city)
        {
            return people.Where(x => x.Adress.City.Equals(city, StringComparison.CurrentCultureIgnoreCase)).ToList();

        }

        public void AddPerson(Person p)
        {
            people.Add(p);
        }


    }
}

