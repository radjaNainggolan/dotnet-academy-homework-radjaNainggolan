using System.ComponentModel.DataAnnotations;
using Library.RadenRovcanin.Contracts.Dtos;

namespace Library.RadenRovcanin.API.CustomAttributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class UsaAddressAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is AddressDto address)
            {
                if (address.Country.Equals("USA", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (IsValid(value))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Invalid request, address should have USA country");
            }
        }
    }
}
