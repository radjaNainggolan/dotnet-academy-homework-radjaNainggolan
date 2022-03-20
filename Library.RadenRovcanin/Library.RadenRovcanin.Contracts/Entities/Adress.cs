namespace Library.RadenRovcanin.Contracts.Entities
{
    /// <summary>
    /// Person adress field object class.
    /// </summary>
    public class Adress
    {
        public string Street { get; set; } = default!;
        public string City { get; set; } = default!;
        public string Country { get; set; } = default!;
    }
}
