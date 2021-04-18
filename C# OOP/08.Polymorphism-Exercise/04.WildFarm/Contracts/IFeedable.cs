using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Contracts
{
    public interface IFeedable
    {
        public int FoodEaten { get; }

        public double WeightMultiplier { get; }

        ICollection<Type> PreferredFoods { get; }

        void Feed(IFood food);


    }
}
