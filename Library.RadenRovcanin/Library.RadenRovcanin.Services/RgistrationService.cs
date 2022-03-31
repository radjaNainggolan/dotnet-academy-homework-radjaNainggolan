using Library.RadenRovcanin.Contracts.Entities;
using Library.RadenRovcanin.Contracts.Requests;
using Library.RadenRovcanin.Contracts.Services;
using Microsoft.AspNetCore.Identity;

namespace Library.RadenRovcanin.Services
{
    public class RgistrationService : IRegistrationService
    {
        private readonly IdentityUser<Person> _userManager;

        public RgistrationService(IdentityUser<Person> userManager)
        {
            _userManager = userManager;
        }

        public async Task Register(RegistrationRequest request)
        {
            
        }
    }
}
