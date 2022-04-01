using Library.RadenRovcanin.Contracts.Entities;
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
                throw new Exception("User already exists!");
            }

            Person user = new(
                request.FirstName,
                request.LastName,
                request.UserName,
                request.Email);

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                var error = string.Join(",", result.Errors.SelectMany(x => x.Description));
                throw new Exception(error);
            }
        }
    }
}
