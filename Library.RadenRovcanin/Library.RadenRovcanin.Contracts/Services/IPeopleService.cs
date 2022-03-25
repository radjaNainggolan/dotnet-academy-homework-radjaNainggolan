using Library.RadenRovcanin.Contracts.Dtos;
namespace Library.RadenRovcanin.Contracts.Services
{
    public interface IPeopleService
    {
        public List<PersonDto> GetAll();

        public PersonDto? GetById(int id);

        public List<PersonDto> GetByCity(string city);

        public void AddPerson(PersonDto p);
    }
}
