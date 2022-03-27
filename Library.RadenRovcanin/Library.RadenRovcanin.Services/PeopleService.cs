using System;
using Library.RadenRovcanin.Contracts.Dtos;
using Library.RadenRovcanin.Contracts.Entities;
using Library.RadenRovcanin.Contracts.Repositories;
using Library.RadenRovcanin.Contracts.Services;
using Library.RadenRovcanin.Data.Db.Repositories;

namespace Library.RadenRovcanin.Services
{
    public class PeopleService : IPeopleService
    {
        private static int autoId = 0;

        private IUnitOfWork _iuow;
        public PeopleService(IUnitOfWork iuow)
        {
            _iuow = iuow;
        }

        public async Task<IEnumerable<PersonDtoResponse>> GetAll()
        {
            var res = await _iuow.People.GetAllAsync();

            var l = res.Select(p => new PersonDtoResponse(
                p.Id,
                p.FirstName,
                p.LastName,
                new AddressDto(
                    p.Address.Street,
                    p.Address.City,
                    p.Address.Country)));

            return l;
        }

        public async Task<PersonDtoResponse?> GetById(int id)
        {
            var res = await _iuow.People.GetByIdAsync(id);
            return new PersonDtoResponse(
                res.Id,
                res.FirstName,
                res.LastName,
                new AddressDto(
                    res.Address.Street,
                    res.Address.City,
                    res.Address.Country));
        }

        public async Task<IEnumerable<PersonDtoResponse>> GetByCity(string city)
        {
            //var res = await _iuow.People.GetByCityAsync(city);
            //return res.Select(p => new PersonDtoResponse(
            //    p.Id,
            //    p.FirstName,
            //    p.LastName,
            //    new AddressDto(
            //        p.Address.Street,
            //        p.Address.City,
            //        p.Address.Country)));

            throw new NotImplementedException();
        }

        public void AddPerson(PersonDtoRequest personDto)
        {
            Person p = new Person(
                autoId++,
                personDto.FirstName,
                personDto.LastName,
                new Address(
                    personDto.Address.Street,
                    personDto.Address.City,
                    personDto.Address.Country));
            _iuow.People.Add(p);
        }
    }
}
