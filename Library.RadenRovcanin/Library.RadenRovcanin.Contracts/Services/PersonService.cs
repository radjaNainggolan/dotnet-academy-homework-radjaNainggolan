using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.RadenRovcanin.Contracts.Dtos;
using Library.RadenRovcanin.Contracts.Entities;

namespace Library.RadenRovcanin.Contracts.Services
{
    public class PersonService
    {

        public List<Person> people = new List<Person>
        {

            new Person("Raden","Rovcanin",  new Adress{Street = "Ostroska 7.", City = "Pljevlja",Country = "Crna Gora"}),
            new Person("Damir","Delijic",  new Adress{Street = "Profesorska 17.", City = "Podgorica",Country = "Crna Gora"}),
            new Person("Rade","Veljic",  new Adress{Street = "Blaza Jovanovica 13.", City = "Spuz",Country = "Crna Gora"})


        };

        public PersonService() { }

        public List<Person> GetAll() 
        {
            return people;

        }

        public Person GetById(int Id) 
        {
            Person p = people.Where(p => p.Id == Id).FirstOrDefault();
            return p;
        
        }

        public List<Person> GetByCity(string city) 
        {
            return people.Where(x => x.Adress.City == city).ToList();
            
        }

        public void AddPerson(Person p) 
        {
            people.Add(p);
        }


    }
}
