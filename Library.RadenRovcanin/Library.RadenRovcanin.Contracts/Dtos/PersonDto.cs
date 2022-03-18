using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Library.RadenRovcanin.Contracts.Entities;

namespace Library.RadenRovcanin.Contracts.Dtos
{
    public class PersonDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Adress is required")]
        public Adress Adress { get; set; }


    }
}
