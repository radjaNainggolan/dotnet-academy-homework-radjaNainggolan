namespace Library.RadenRovcanin.Contracts
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string? message = "Entity not found in system") : base(message)
        {
        }
    }
}
