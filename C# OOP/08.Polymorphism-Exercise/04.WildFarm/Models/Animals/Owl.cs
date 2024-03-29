﻿using _04.WildFarm.Contracts;
using _04.WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models
{
    public class Owl : Bird
    {

        public Owl(string name, double weight, double wingsize) : base(name, weight, wingsize)
        {

        }

        public override double WeightMultiplier => 0.25;

        public override ICollection<Type> PreferredFoods => new List<Type>() { typeof(Meat) };

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
