using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Pattern
{
    public class Product
    {
        private List<object> _parts = new List<object>();

        public Product()
        { }

        public void Add(object part)
        {
            this._parts.Add(part);
        }

        public void Show()
        {
            foreach (var item in this._parts)
            {
                Console.WriteLine(item);
            }
        }
    }
}
