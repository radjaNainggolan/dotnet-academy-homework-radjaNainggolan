namespace Library.RadenRovcanin.Contracts.Services
{
    using System.Collections.Generic;
    using Library.RadenRovcanin.Contracts.Entities;

    public interface IPeopleService
    {
        public List<Person> GetAll();

        public Person GetById(int id);

        public List<Person> GetByCity(string city);

        public void AddPerson(Person p);
    }
}
