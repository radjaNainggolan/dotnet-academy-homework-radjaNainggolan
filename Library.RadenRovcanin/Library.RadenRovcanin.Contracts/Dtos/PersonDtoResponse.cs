using System.ComponentModel.DataAnnotations;
namespace Library.RadenRovcanin.Contracts.Dtos
{
    public class PersonDtoResponse
    {
        public int Id { get; set; } = default!;

        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; } = default!;

        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; } = default!;

        public PersonDtoResponse()
        {
        }

        public PersonDtoResponse(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
