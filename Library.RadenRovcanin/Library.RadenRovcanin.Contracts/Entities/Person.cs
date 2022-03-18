using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.RadenRovcanin.Contracts.Entities
{
    public class Person
    {
        public int Id { get; set; } = 0;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Adress Adress { get; set; }


        public Person( string FirstName, string LastName, Adress adress) {
            this.Id++;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Adress = adress;
        }

    }
}
