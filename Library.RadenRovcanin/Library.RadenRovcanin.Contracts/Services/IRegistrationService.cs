using Library.RadenRovcanin.Contracts.Requests;

namespace Library.RadenRovcanin.Contracts.Services
{
    public interface IRegistrationService
    {
        public Task Register(RegistrationRequest request);
    }
}
