using Library.RadenRovcanin.Contracts.Dtos;
namespace Library.RadenRovcanin.Contracts.Services
{
    public interface IPeopleService
    {
        public List<PersonDtoResponse> GetAll();

        public PersonDtoResponse? GetById(int id);

        public List<PersonDtoResponse> GetByCity(string city);

        public void AddPerson(PersonDtoRequest p);
    }
}
