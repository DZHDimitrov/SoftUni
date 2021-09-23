using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator_Pattern
{
    public class WithSugar : CoffeeDecorator
    {
        public WithSugar(Coffee coffee) : base(coffee)
        {}

        public override double cost()
        {
            return this.coffee.cost() + 0.15;
        }

        public override string GetDescription()
        {
            return this.coffee.GetDescription() + " " + ",Sugar";
        }
    }
}
