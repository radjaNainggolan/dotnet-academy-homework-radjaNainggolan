using System.Security.Claims;
using Library.RadenRovcanin.Contracts.Dtos;
using Library.RadenRovcanin.Contracts.Entities;
using Library.RadenRovcanin.Contracts.Requests;
using Library.RadenRovcanin.Contracts.Services;
using Microsoft.AspNetCore.Identity;

namespace Library.RadenRovcanin.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<Person> _userManager;
        private readonly ITokenGenerator _tokenGenerator;

        public AuthenticationService(UserManager<Person> userManager, ITokenGenerator tokenGenerator)
        {
            _userManager = userManager;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<TokenDto> Login(AuthenticationRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                throw new Exception("User not found in system");
            }

            var isValidPassword = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!isValidPassword)
            {
                throw new Exception("Invalid password!");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("FullName", user.FullName),
                new Claim("Id", user.Id.ToString()),
            };

            return _tokenGenerator.GenerateToken(claims);
        }
    }
}
