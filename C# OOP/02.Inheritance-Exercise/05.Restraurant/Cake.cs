using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    class Cake : Dessert
    {
        private const double gramsByDefault = 250;
        private const double caloriesByDefault = 1000;
        private const decimal cakePriceByDefault = 5; 

        public Cake(string name) : base(name, cakePriceByDefault, gramsByDefault, caloriesByDefault)
        {

        }
    }
}
