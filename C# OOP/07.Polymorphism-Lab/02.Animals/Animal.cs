using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class Animal
    {
        public Animal(string name,string favouriteFood)
        {
            Name = name;
            FavouriteFood = favouriteFood;
        }
        public string Name { get; }
        public string FavouriteFood { get; }

        public virtual string ExplainSelf()
        {
            return $"I am {Name} and my fovourite food is {FavouriteFood}";
        }
            

    }
}
