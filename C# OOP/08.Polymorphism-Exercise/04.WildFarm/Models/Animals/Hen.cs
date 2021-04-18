using _04.WildFarm.Models.Foods;
using System;
using System.Collections.Generic;

namespace _04.WildFarm.Models
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingsize) : base(name, weight, wingsize)
        {

        }

        public override double WeightMultiplier => 0.35;

        public override ICollection<Type> PreferredFoods => new List<Type>() { typeof(Meat), typeof(Vegetable), typeof(Seeds), typeof(Fruit) };

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
