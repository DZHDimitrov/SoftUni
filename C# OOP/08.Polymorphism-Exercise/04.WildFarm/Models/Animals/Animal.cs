using _04.WildFarm.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models
{
    public abstract class Animal : IAnimal, IFeedable, ISoundProducable
    {
        private const string INVALID_FOOD_EXC_MSG = "{0} does not eat {1}!";

        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }
        public int FoodEaten { get; private set; }

        public abstract double WeightMultiplier { get; }

        public abstract ICollection<Type> PreferredFoods { get; }

        public string Name { get; }

        public double Weight { get; private set; }

        public void Feed(IFood food)
        {
            if (!PreferredFoods.Contains(food.GetType()))
            {
                throw new InvalidOperationException(string.Format(INVALID_FOOD_EXC_MSG, this.GetType().Name, food.GetType().Name));
            }

            FoodEaten += food.FoodQuantity;
            Weight += food.FoodQuantity * WeightMultiplier;
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, ";
        }

    }
}
