﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.RadenRovcanin.Contracts.Entities
{
    public class Person
    {   
        static int AutoId = 0;
        public int Id { get; set; } = AutoId++;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Adress Adress { get; set; } = default!;


        public Person(string FirstName, string LastName, Adress adress) {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Adress = adress;
        }

        
    }
}
