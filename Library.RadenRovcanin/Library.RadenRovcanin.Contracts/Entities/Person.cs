namespace Library.RadenRovcanin.Contracts.Entities
{
    /// <summary>
    /// Person entity class.
    /// </summary>
    public class Person
    {
        static int AutoId = 0;
        public int Id { get; set; } = default!;

        public string FirstName { get; set; } = default!;
        
        public string LastName { get; set; } = default!;
        
        public Adress Adress { get; set; } = default!;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        public Person()
        {}

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        /// <param name="firstName">First name.</param>
        /// <param name="lastName">Last name.</param>
        /// <param name="adress">Adress.</param>
        public Person(string firstName, string lastName, Adress adress)
        {
            this.Id = AutoId++;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Adress = adress;
        }
    }
}
