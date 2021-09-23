using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator_Pattern
{
    public abstract class Coffee
    {
        public string Description { get; set; } = "Unknown Coffee";

        public abstract string GetDescription();

        public abstract double cost();
    }
}
