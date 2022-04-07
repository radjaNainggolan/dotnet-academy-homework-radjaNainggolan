namespace Library.RadenRovcanin.Contracts.Exceptions
{
    public class UserRegistrationException : Exception
    {
        public UserRegistrationException(string? message = "Some error occurred, User is not registered!") : base(message)
        {
        }
    }
}
