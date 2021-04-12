using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    class Dough
    {
        private const double caloriesPerGramByDefault = 2;

        private string flourType;
        private string bakingTechnique;
        private int weight;

        private double flourTypeModifier = 0;
        private double bakingTechniqueModifier = 0;


        public Dough(string flourType, string bakingTechnique, int weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;

            flourTypeModifier = GetFlourModifier(FlourType);
            bakingTechniqueModifier = GetTechniqueModifier(BakingTechnique);
        }
       
        public string FlourType 
        { 
            get
            {
                return flourType;
            }
            set
            {
                if (value != "white" && value != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                flourType = value;
            }
        }

        public string BakingTechnique
        { 
            get
            {
                return bakingTechnique;
            }
            set
            {
                if (value != "crispy" && value != "chewy" && value != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechnique = value;
            }
        }

        public int Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                weight = value;
            }
        }
        public double Calories 
        { 
            get
            {
                return (caloriesPerGramByDefault * Weight) * flourTypeModifier * bakingTechniqueModifier;
            }
                
        }

        private double GetFlourModifier(string flourtype)
        {
            switch (flourtype)
            {
                case "white":
                    return 1.5;
                case "wholegrain":
                    return 1.0;
            }
            return 0;
        }
        private double GetTechniqueModifier(string technique)
        {
            switch (technique)
            {
                case "crispy":
                    return 0.9;
                case "chewy":
                    return 1.1;
                case "homemade":
                    return 1.0;
            }
            return 0;
        }

    }
}
