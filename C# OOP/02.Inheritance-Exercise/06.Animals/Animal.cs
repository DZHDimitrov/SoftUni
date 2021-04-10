using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    abstract class Animal
    {
        private int age;

        public Animal(string animalType, string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
            AnimalType = animalType;
        }

        public string Name { get; set; }

        public int Age {
            get
            {
                return this.age; 
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                age = value;
            }
        }

        public string Gender { get; set; }

        public string AnimalType { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(AnimalType);
            sb.AppendLine($"{Name} {Age} {Gender}");
            sb.AppendLine(ProduceSound());

            return sb.ToString().TrimEnd();
        }

        public abstract string ProduceSound();
    }
}
