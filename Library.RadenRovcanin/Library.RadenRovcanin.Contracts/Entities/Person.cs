using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.RadenRovcanin.Contracts.Entities
{
    internal class Person
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }

        public Adress adress { get; set; }


    }
}
