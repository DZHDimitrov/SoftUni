using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    class Kitten : Cat
    {
        private const string genderByDefault = "female";

        public Kitten(string name, int age) : base(name, age, genderByDefault)
        {

        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
