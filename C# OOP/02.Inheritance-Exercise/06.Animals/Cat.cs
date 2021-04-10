using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    class Cat : Animal
    {
        private const string animalTypeByDefault = "Cat";
        public Cat(string name, int age, string gender) : base(animalTypeByDefault, name, age, gender)
        {
        }

        public override string ProduceSound()
        {
            return "Meow meow";
        }
    }
}
