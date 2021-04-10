using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    class Dog : Animal
    {
        private const string animalTypeByDefault = "Dog";

        public Dog(string name, int age, string gender) : base(animalTypeByDefault, name, age, gender)
        {

        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
