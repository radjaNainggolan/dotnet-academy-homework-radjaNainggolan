using System.Security.Claims;
using Library.RadenRovcanin.Contracts.Dtos;

namespace Library.RadenRovcanin.Contracts.Services
{
    public interface ITokenGenerator
    {
        public TokenDto GenerateToken(List<Claim> claims);
    }
}
