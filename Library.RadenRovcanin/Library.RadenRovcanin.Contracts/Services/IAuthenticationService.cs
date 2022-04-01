using Library.RadenRovcanin.Contracts.Dtos;
using Library.RadenRovcanin.Contracts.Requests;

namespace Library.RadenRovcanin.Contracts.Services
{
    public interface IAuthenticationService
    {
        public Task<TokenDto> Login(AuthenticationRequest request);
    }
}
