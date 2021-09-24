using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Pattern
{
    public class ConcreteBuilder : IBuilder
    {
        private Product _product = new Product();

        public IBuilder BuildPartA(object obj)
        {
            this._product.Add(obj);
            return this;
        }

        public IBuilder BuildPartB(object obj)
        {
            this._product.Add(obj);
            return this;
        }

        public IBuilder BuildPartC(object obj)
        {
            this._product.Add(obj);
            return this;
        }

        public void Reset()
        {
            this._product = new Product();
        }

        public Product GetProduct()
        {
            Product result = this._product;
            this.Reset();
            return result;
        }
    }
}
