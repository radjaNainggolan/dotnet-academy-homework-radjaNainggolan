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

        private readonly IUnitOfWork _iuow;
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
                new AddressDto()));

            return l;
        }

        public async Task<PersonDtoResponse?> GetById(int id)
        {
            var res = await _iuow.People.GetByIdAsync(id);
            return new PersonDtoResponse(
                res.Id,
                res.FirstName,
                res.LastName,
                new AddressDto());
        }

        public Task<IEnumerable<PersonDtoResponse>> GetByCity(string city)
        {
            throw new NotImplementedException();
        }

        public void AddPerson(PersonDtoRequest personDto)
        {
            Person p = new(
                personDto.FirstName,
                personDto.LastName
                );
            _iuow.People.Add(p);
        }
    }
}
