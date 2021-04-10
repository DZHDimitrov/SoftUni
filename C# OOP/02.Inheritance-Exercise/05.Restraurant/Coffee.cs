using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    class Coffee : HotBeverage
    {
        private const double mililitersByDefault = 50;
        private const decimal priceByDefault = 3.50m;
        public Coffee(string name, double caffeine) : base(name, priceByDefault, mililitersByDefault)
        {
            Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
    }
}
