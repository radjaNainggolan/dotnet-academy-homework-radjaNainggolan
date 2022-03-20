using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.RadenRovcanin.Contracts.Dtos;
using Library.RadenRovcanin.Contracts.Entities;

namespace Library.RadenRovcanin.Contracts.Services
{
    public interface IPeopleService
    {
        public List<Person> GetAll();

        public Person GetById(int id);

        public List<Person> GetByCity(string city);

        public void AddPerson(Person p);
    }
}
