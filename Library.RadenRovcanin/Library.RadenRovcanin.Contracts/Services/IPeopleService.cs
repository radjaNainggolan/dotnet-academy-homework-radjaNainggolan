using Library.RadenRovcanin.Contracts.Dtos;
namespace Library.RadenRovcanin.Contracts.Services
{
    public interface IPeopleService
    {
        public Task<IEnumerable<PersonDtoResponse>> GetAll();

        public Task<PersonDtoResponse?> GetById(int id);

        public Task<IEnumerable<PersonDtoResponse>> GetByCity(string city);

        public void AddPerson(PersonDtoRequest p);
    }
}
