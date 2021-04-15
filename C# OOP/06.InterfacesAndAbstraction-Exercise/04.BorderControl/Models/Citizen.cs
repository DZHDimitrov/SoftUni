using _05.BorderControl.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BorderControl.Models
{
    public class Citizen : IID
    {
        public Citizen(string name, int age, string id)
        {
            Name = name;
            Age = age;
            ID = id;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string ID { get; set; }
    }
}
