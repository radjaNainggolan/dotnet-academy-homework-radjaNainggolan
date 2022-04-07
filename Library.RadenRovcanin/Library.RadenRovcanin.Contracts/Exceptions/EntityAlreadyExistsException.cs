namespace Library.RadenRovcanin.Contracts.Exceptions
{
    public class EntityAlreadyExistsException : Exception
    {
        public EntityAlreadyExistsException(string? message = "Entity already exists in system") : base(message)
        {
        }
    }
}
