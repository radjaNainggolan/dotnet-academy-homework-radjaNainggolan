namespace Library.RadenRovcanin.Contracts.Entities
{
    public class Person
    {
        static int AutoId = 0;
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Adress Adress { get; set; } = default!;


        public Person(string FirstName, string LastName, Adress adress)
        {
            this.Id = AutoId++;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Adress = adress;
        }


    }
}
