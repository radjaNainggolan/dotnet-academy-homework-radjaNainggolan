using Library.RadenRovcanin.Contracts.Dtos;
using Library.RadenRovcanin.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.RadenRovcanin.Contracts.Services
{
    /// <summary>
    /// People service interface.
    /// </summary>
    public interface IPeopleService
    {
        /// <summary>
        /// Contract that return all people from list.
        /// </summary>
        /// <returns>list.</returns>
        public List<Person> GetAll();

        /// <summary>
        /// Contract that return person with certan id.
        /// </summary>
        /// <param name="id">Person id.</param>
        /// <returns>Person.</returns>
        public Person GetById(int id);

        /// <summary>
        /// contract that returns list of people from given city.
        /// </summary>
        /// <param name="city">Query param.</param>
        /// <returns>List.</returns>
        public List<Person> GetByCity(string city);


        /// <summary>
        /// contract for adding new person to list.
        /// </summary>
        /// <param name="p">PersonDto.</param>
        public void AddPerson(Person p);
    }
}
