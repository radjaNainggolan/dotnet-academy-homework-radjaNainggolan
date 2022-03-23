using System.ComponentModel.DataAnnotations;
using Library.RadenRovcanin.Contracts.Entities;
namespace Library.RadenRovcanin.Contracts.Dtos
{
    public class PersonDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Adress is required")]
        public Adress Adress { get; set; }

        public PersonDto(int id, string firstName, string lastName, Adress adress)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Adress = adress;
        }

        public static Person ToPerson(PersonDto p)
        {
            return new Person(p.FirstName, p.LastName, p.Adress);
        }
    }
}
