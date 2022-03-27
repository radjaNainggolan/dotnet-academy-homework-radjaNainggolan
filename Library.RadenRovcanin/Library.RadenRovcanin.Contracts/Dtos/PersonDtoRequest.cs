using System.ComponentModel.DataAnnotations;
namespace Library.RadenRovcanin.Contracts.Dtos
{
    public class PersonDtoRequest
    {
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; } = default!;

        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; } = default!;

        public PersonDtoRequest()
        {
        }

        public PersonDtoRequest(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
