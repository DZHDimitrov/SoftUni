using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator_Pattern
{
    public class WithMilk : CoffeeDecorator
    {
        public WithMilk(Coffee coffee) : base(coffee)
        {
        }

        public override double cost()
        {
            return coffee.cost() + .50;
        }

        public override string GetDescription()
        {
            return this.coffee.GetDescription() + " " + ",Milk";
        }
    }
}
