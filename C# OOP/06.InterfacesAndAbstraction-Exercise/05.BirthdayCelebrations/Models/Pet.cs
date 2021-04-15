using System;
using System.Collections.Generic;
using System.Text;

namespace _06.BirthdayCelebrations.Models
{
    public class Pet : IBirthdate
    {
        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }
        public string Name { get; set; }
        public string Birthdate { get; set; }
    }
}
