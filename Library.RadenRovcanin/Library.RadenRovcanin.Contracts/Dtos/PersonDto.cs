using System.ComponentModel.DataAnnotations;
namespace Library.RadenRovcanin.Contracts.Dtos
{
    public class PersonDto
    {
        public int Id { get; set; } = default!;

        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; } = default!;

        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; } = default!;

        [Required(ErrorMessage = "Address is required")]
        public AddressDto AddressDto { get; set; } = default!;

        public PersonDto(int id, string firstName, string lastName, AddressDto address)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            AddressDto = address;
        }
    }
}
