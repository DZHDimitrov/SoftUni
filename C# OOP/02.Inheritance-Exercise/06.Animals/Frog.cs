using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    class Frog : Animal
    {
        private const string animalTypeByDefault = "Frog";
        public Frog(string name, int age, string gender) : base(animalTypeByDefault, name, age, gender)
        {

        }

        public override string ProduceSound()
        {
            return "Ribbit";
        }
    }
}
