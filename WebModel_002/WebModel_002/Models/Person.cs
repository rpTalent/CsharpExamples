using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebModel_002.Models
{
    public class Person
    {
        public string PersonId { get; set; }

        [Display(Name = "Imię")]
        [Required(ErrorMessage = "Pole Imię jest wymagane")]
        public string FirstName { get; set; }

        [Display(Name = "Nazwisko")]
        [Required(ErrorMessage = "Pole Nazwisko jest wymagane")]
        public string SureName { get; set; }

        [Display(Name = "Płeć")]
        [Required(ErrorMessage = "Pole Płeć jest wymagane")]
        public Char Sex { get; set; }

        [Display(Name = "Data urodzenia")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Adres email")]
        public string Email { get; set; }

        [Display(Name = "Numer telefonu")]
        public string PhoneNumber { get; set; }
    }
}