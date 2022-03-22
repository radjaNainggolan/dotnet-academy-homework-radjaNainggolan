namespace Library.RadenRovcanin.Contracts.Entities
{
    public class Person
    {
        private static int autoId = 0;
        public int Id { get; set; } = default!;

        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public Adress Adress { get; set; } = default!;

        public Person()
        {
        }

        public Person(string firstName, string lastName, Adress adress)
        {
            this.Id = autoId++;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Adress = adress;
        }
    }
}
