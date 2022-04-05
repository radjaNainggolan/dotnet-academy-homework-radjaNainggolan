namespace Library.RadenRovcanin.Contracts.Dtos
{
    public class TokenDto
    {
        public string Token { get; set; } = default!;

        public DateTime ExpiresAt { get; set; } = default!;
    }
}
