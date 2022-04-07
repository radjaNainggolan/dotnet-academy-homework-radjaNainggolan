using System.ComponentModel.DataAnnotations;
using Library.RadenRovcanin.API.CustomAttributes;
using Library.RadenRovcanin.Contracts.Dtos;
namespace Library.RadenRovcanin.Contracts.Requests
{
    public class RegistrationRequest
    {
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; } = default!;

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; } = default!;

        [Required(ErrorMessage = "User name is required")]
        public string UserName { get; set; } = default!;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; } = default!;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = default!;

        [Required(ErrorMessage = "Age is required")]
        public int Age { get; set; } = default!;

        [Required(ErrorMessage = "Address is required")]
        [UsaAddress]
        public AddressDto Address { get; set; } = default!;
    }
}
