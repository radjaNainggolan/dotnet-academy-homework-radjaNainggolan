using System.ComponentModel.DataAnnotations;
namespace Library.RadenRovcanin.Contracts.Dtos
{
    public class PersonDtoRequest
    {
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; } = default!;

        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; } = default!;

        [Required(ErrorMessage = "Address is required")]
        public AddressDto Address { get; set; } = default!;

        public PersonDtoRequest()
        {
        }

        public PersonDtoRequest(string firstName, string lastName, AddressDto address)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
        }
    }
}
