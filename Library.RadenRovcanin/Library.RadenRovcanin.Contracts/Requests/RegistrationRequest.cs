using System.ComponentModel.DataAnnotations;

namespace Library.RadenRovcanin.Contracts.Requests
{
    public class RegistrationRequest
    {
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; } = default!;

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; } = default!;

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = default!;

        [Required(ErrorMessage = "Password is required")]
        public string UserName { get; set; } = default!;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = default!;

        [Required(ErrorMessage = "Password is required")]
        public int Age { get; set; } = default!;
    }
}
