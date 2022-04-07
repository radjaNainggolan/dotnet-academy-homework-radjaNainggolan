using Library.RadenRovcanin.Contracts.Dtos;
using Library.RadenRovcanin.Contracts.Repositories;
using Library.RadenRovcanin.Contracts.Services;

namespace Library.RadenRovcanin.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly IUnitOfWork _iuow;
        public PeopleService(IUnitOfWork iuow)
        {
            _iuow = iuow;
        }

        public async Task<IEnumerable<PersonDtoResponse>> GetAll()
        {
            var res = await _iuow.People.GetAllWithAddressAsync();
            return res.Select(p => new PersonDtoResponse(
                p.Id,
                p.FirstName,
                p.LastName,
                new AddressDto(
                    p.Address.Street,
                    p.Address.City,
                    p.Address.Country)));
        }

        public async Task<PersonDtoResponse?> GetById(int id)
        {
            var p = await _iuow.People.GetByIdWithAddressAsync(id);

            if (p == null)
            {
                throw new EntryPointNotFoundException("Person with this ID is not found in system");
            }

            return new PersonDtoResponse(
                p.Id,
                p.FirstName,
                p.LastName,
                new AddressDto(
                    p.Address.Street,
                    p.Address.City,
                    p.Address.Country));
        }

        public async Task<IEnumerable<PersonDtoResponse>> GetByCity(string city)
        {
            var res = await _iuow.People.GetByCityAsync(city);
            return res.Select(p => new PersonDtoResponse(
                p.Id,
                p.FirstName,
                p.LastName,
                new AddressDto(
                    p.Address.Street,
                    p.Address.City,
                    p.Address.Country)));
        }

        public async Task AddPerson(PersonDtoRequest personDto)
        {
            //Person p = new(
            //    personDto.FirstName,
            //    personDto.LastName);
            //_iuow.People.Add(p);
            await _iuow.SaveChangesAsync();
        }
    }
}
