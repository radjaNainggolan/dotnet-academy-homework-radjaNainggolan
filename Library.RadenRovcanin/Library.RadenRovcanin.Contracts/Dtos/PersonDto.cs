// <copyright file="PersonDto.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using Library.RadenRovcanin.Contracts.Entities;

namespace Library.RadenRovcanin.Contracts.Dtos
{
    /// <summary>
    /// Data transfer object class.
    /// </summary>
    public class PersonDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Adress is required")]
        public Adress Adress { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonDto"/> class.
        /// </summary>
        /// <param name="id">id of person.</param>
        /// <param name="firstName">First name.</param>
        /// <param name="lastName">Last name.</param>
        /// <param name="adress">Adress.</param>
        public PersonDto(int id, string firstName, string lastName, Adress adress)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Adress = adress;
        }

        /// <summary>
        /// Maps Dto to person.
        /// </summary>
        /// <param name="p">Dto to map.</param>
        /// <returns>new Person.</returns>>
        public static Person ToPerson(PersonDto p)
        {
            return new Person(p.FirstName, p.LastName, p.Adress);
        }
    }
}
