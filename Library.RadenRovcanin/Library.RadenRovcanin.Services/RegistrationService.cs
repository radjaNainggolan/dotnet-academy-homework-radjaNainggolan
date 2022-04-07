using Library.RadenRovcanin.Contracts.Entities;
using Library.RadenRovcanin.Contracts.Exceptions;
using Library.RadenRovcanin.Contracts.Requests;
using Library.RadenRovcanin.Contracts.Services;
using Microsoft.AspNetCore.Identity;

namespace Library.RadenRovcanin.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly UserManager<Person> _userManager;

        public RegistrationService(UserManager<Person> userManager)
        {
            _userManager = userManager;
        }

        public async Task Register(RegistrationRequest request)
        {
            var existingUser = await _userManager.FindByEmailAsync(request.Email);
            if (existingUser != null)
            {
                throw new EntityAlreadyExistsException("User already exists!");
            }

            Person user = new(
                request.FirstName,
                request.LastName,
                request.Email,
                request.UserName,
                request.Age,
                new Address(
                    request.Address.Street,
                    request.Address.City,
                    request.Address.Country));

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                var error = string.Concat(result.Errors.Select(x => x.Description));
                throw new UserRegistrationException(error);
            }
        }
    }
}
