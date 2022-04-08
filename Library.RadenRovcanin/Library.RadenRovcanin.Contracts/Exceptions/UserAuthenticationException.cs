namespace Library.RadenRovcanin.Contracts.Exceptions
{
    public class UserAuthenticationException : Exception
    {
        public UserAuthenticationException(string? message = "Invalid password") : base(message)
        {
        }
    }
}
