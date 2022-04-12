using Library.RadenRovcanin.Contracts.Entities;

namespace Library.RadenRovcanin.Services.Tests
{
    public static class PersonMock
    {
        public static Person Build()
        {
            return new Person(
                1,
                "First Name",
                "Last Name",
                "Username",
                "Email",
                18,
                new Address(
                    "Street",
                    "City",
                    "Country"));
        }
    }
}
