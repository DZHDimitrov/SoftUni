using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Pattern
{
    public class Director
    {
        private IBuilder _builder;

        public IBuilder Builder
        {
            set { _builder = value; }
        }

        public void BuildMinimalViableProduct()
        {
            this._builder.BuildPartA("First_Part");
        }

        public void BuildFullFeaturedProduct()
        {
            this._builder.BuildPartA("First_Part").BuildPartB("Second_Part").BuildPartC("Third_Part");
        }

    }
}
