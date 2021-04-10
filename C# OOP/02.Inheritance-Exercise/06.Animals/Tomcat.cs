using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    class Tomcat : Cat
    {
        private const string genderByDefault = "male";

        public Tomcat(string name, int age) : base(name, age, genderByDefault)
        {

        }

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
