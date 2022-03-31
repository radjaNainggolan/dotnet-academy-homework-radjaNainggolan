using Library.RadenRovcanin.Contracts.Dtos;
using Library.RadenRovcanin.Contracts.Requests;

namespace Library.RadenRovcanin.Contracts.Services
{
    public interface IAuthenticationService
    {
        Task<TokenDto> Login(AuthenticationRequest request);
    }
}
