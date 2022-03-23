using System.ComponentModel.DataAnnotations;

namespace Library.RadenRovcanin.Contracts.Dtos
{
    public class AddressDto
    {
        [Required(ErrorMessage = "Street is required")]
        public string Street { get; set; } = default!;

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; } = default!;

        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; } = default!;

        public AddressDto(string street, string city, string country)
        {
            Street = street;
            City = city;
            Country = country;
        }
    }
}
