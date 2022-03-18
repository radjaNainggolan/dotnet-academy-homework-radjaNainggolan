using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.RadenRovcanin.Contracts.Dtos;
using Library.RadenRovcanin.Contracts.Entities;

namespace Library.RadenRovcanin.Contracts.Services
{
    internal class PersonService
    {

        public List<Person> people = new List<Person> 
        { 
            
            new Person{ 
                Id = 1,
                FirstName = "Raden",
                LastName = "Rovcanin",
                Adress = new Adress{ 
                    Street = "Ostroska 7.",
                    City = "Pljevlja",
                    Country = "Crna Gora"
                }
            },

            new Person{ 
                Id=2,
                FirstName = "Rade",
                LastName = "Vljeic",
                Adress = new Adress { 
                    Street = "Blaza Jovanovica 14.",
                    City = "Spuz",
                    Country = "Crna Gora"
                }
            },

            new Person{
                Id=3,
                FirstName = "Damir",
                LastName = "Delijic",
                Adress = new Adress {
                    Street = "Profesorksa 27.",
                    City = "Podgorica",
                    Country = "Crna Gora"
                }
            }


        };


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
