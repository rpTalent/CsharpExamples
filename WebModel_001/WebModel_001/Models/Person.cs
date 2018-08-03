using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebModel_001.Models
{
    public class Person
    {
        public string PersonId { get; set; }
        public string FirstName { get; set; }
        public string SureName { get; set; }
        public Char Sex { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}