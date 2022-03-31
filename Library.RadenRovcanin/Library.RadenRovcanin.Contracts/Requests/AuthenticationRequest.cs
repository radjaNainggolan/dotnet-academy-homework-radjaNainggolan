using System.ComponentModel.DataAnnotations;

namespace Library.RadenRovcanin.Contracts.Requests
{
    public class AuthenticationRequest
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email is required!")]
        public string Email { get; set; } = default!;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = default!;
    }
}
