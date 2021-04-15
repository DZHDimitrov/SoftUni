using _10.ExplicitInterfaces.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _10.ExplicitInterfaces.Models
{
    public class Citizen : IPerson, IResident
    {
        public Citizen(string name, string country, int age)
        {
            Name = name;
            Country = country;
            Age = age;
        }
        public string Name { get; }

        public int Age { get; }

        public string Country { get; }

        string IPerson.GetName()
        {
            return $"{Name}";
        }
        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {Name}";
        }
    }
}
