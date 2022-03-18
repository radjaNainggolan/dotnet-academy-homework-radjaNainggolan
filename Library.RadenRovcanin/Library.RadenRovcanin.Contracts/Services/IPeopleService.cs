using Library.RadenRovcanin.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.RadenRovcanin.Contracts.Services
{
    public interface IPeopleService
    {

        public List<Person> GetAll();

        public Person GetById(int Id);

        public List<Person> GetByCity(string city);

        public void AddPerson(Person p);
    }
}
