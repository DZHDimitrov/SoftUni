using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator_Pattern
{
    public class Espresso : Coffee
    {
        public Espresso()
        {
            this.Description = "Espresso";
        }

        public override double cost()
        {
            return 1.99;
        }

        public override string GetDescription()
        {
            return this.Description;
        }
    }
}
