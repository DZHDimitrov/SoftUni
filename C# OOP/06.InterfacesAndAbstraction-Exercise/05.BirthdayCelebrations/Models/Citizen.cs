﻿using _06.BirthdayCelebrations;

namespace _05.BorderControl.Models
{
    public class Citizen : IBirthdate
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            ID = id;
            Birthdate = birthdate;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string ID { get; set; }
        public string Birthdate { get; set; }
    }
}